using System;
using System.Net;

namespace SimpleFirebaseUnity
{
    public class FirebaseError : Exception
    {
		const string MESSAGE_ERROR_400 = "Firebase request has an error / bad request. See https://firebase.google.com/docs/reference/rest/database/ for more details.";
		const string MESSAGE_ERROR_401 = "Firebase request's authorization has failed. See https://firebase.google.com/docs/reference/rest/database/ for more details.";
		const string MESSAGE_ERROR_404 = "The specified Realtime Database was not found.";
		const string MESSAGE_ERROR_500 = "The server returned an error.";
		const string MESSAGE_ERROR_503 = "The specified Firebase Realtime Database is temporarily unavailable, which means the request was not attempted.";
		const string MESSAGE_ERROR_412 = "The request's specified ETag value in the if-match header did not match the server's value.";
		const string MESSAGE_ERROR_UNDEFINED = "Undefined error: ";

		protected HttpStatusCode m_Status;


		public FirebaseError(HttpStatusCode status, string message) : base(message)
		{
			m_Status = status;
		}

		public FirebaseError(HttpStatusCode status, string message, Exception inner) : base(message, inner)
		{
			m_Status = status;
		}

		public FirebaseError(string message) : base(message)
		{
		}

		public FirebaseError(string message, Exception inner) : base(message, inner)
		{
		}


		/// <summary>
		/// Create the FirebaseError initialized based on the given WebException.
		/// </summary>
		/// <param name="webEx">Web exception.</param>
		public static FirebaseError Create(WebException webEx)
		{
			string message;
			HttpStatusCode status = 0;
			bool isStatusAvailable = false;

			if (webEx.Status == WebExceptionStatus.ProtocolError)
			{
				HttpWebResponse response = webEx.Response as HttpWebResponse;
				if (response != null) 
				{
					status = response.StatusCode;
					isStatusAvailable = true;
				}
			}

			if (!isStatusAvailable)
				return new FirebaseError(webEx.Message, webEx);

			switch (status) 
			{
				case HttpStatusCode.Unauthorized:
					message = MESSAGE_ERROR_401;
					break;
				case HttpStatusCode.BadRequest:
					message = MESSAGE_ERROR_400;
					break;
				case HttpStatusCode.NotFound:
					message = MESSAGE_ERROR_404;
					break;
				case HttpStatusCode.InternalServerError:
					message = MESSAGE_ERROR_500 + "\n(" + webEx.Message + ")";
                    break;
				case HttpStatusCode.ServiceUnavailable:
					message = MESSAGE_ERROR_503;
                    break;
				case HttpStatusCode.PreconditionFailed:
					message = MESSAGE_ERROR_412;
					break;
				default:
					message = webEx.Message;
					break;
			}

			return new FirebaseError(status, message, webEx);
		}
			
		/// <summary>
		/// Create the FirebaseError initialized based on the given http status code.
		/// </summary>
		/// <param name="status">Http status code.</param>
		public static FirebaseError Create(HttpStatusCode status)
		{
			string message;

			switch (status)
            {
                case HttpStatusCode.Unauthorized:
                    message = MESSAGE_ERROR_401;
                    break;
                case HttpStatusCode.BadRequest:
                    message = MESSAGE_ERROR_400;
                    break;
                case HttpStatusCode.NotFound:
                    message = MESSAGE_ERROR_404;
                    break;
                case HttpStatusCode.InternalServerError:
					message = MESSAGE_ERROR_500 + ". See the error message for further details.";
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    message = MESSAGE_ERROR_503;
                    break;
                case HttpStatusCode.PreconditionFailed:
                    message = MESSAGE_ERROR_412;
                    break;
                default:
					message = MESSAGE_ERROR_UNDEFINED + status.ToString();
                    break;
            }

			return  new FirebaseError (status, message);
		}

		/// <summary>
		/// Gets the status code. 
		/// Tips: Typecast to integer to get the code. You could also typecast to string to print as it is.
		/// </summary>
		/// <value>The status.</value>
		public HttpStatusCode Status
		{
			get{
				return m_Status;
			}
		}
    }
}
