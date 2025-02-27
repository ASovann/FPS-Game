﻿

using UnityEngine;
using System.Collections;
using System;

namespace SimpleFirebaseUnity
{
	public class FirebaseObserver  {

		public Action<Firebase, DataSnapshot> OnChange; 

		protected Firebase firebase;
		protected Firebase target;
		protected float refreshRate;
		protected string getParam;
		protected bool active;

		protected bool firstTime;
		protected DataSnapshot lastSnapshot;

		protected IEnumerator routine;


		#region CONSTRUCTORS

		/// <summary>
		/// Creates an Observer that calls GetValue request at the given refresh rate (in seconds) and checks whether the value has changed.
		/// </summary>
		/// <param name="_firebase">Firebase.</param>
		/// <param name="_refreshRate">Refresh rate (in seconds).</param>
		/// <param name="_getParam">Parameter value for the Get request that will be called periodically.</param>
		public FirebaseObserver(Firebase _firebase, float _refreshRate, string _getParam = "")
		{
			active = false;
			lastSnapshot = null;
			firebase = _firebase;
			refreshRate = _refreshRate;
			getParam = _getParam;
			target = _firebase.Copy ();
			routine = null;
		}

		/// <summary>
		/// Creates an Observer that calls GetValue request at the given refresh rate (in seconds) and checks whether the value has changed.
		/// </summary>
		/// <param name="_firebase">Firebase.</param>
		/// <param name="_refreshRate">Refresh rate (in seconds).</param>
		/// <param name="_getParam">Parameter value for the Get request that will be called periodically.</param>
		public FirebaseObserver(Firebase _firebase, float _refreshRate, FirebaseParam _getParam)
		{
			active = false;
			lastSnapshot = null;
			firebase = _firebase;
			refreshRate = _refreshRate;
			getParam = _getParam.Parameter;
			target = _firebase.Copy ();
		}

		#endregion

		#region OBSERVER FUNCTIONS

		/// <summary>
		/// Start the observer.
		/// </summary>
		public void Start()
		{
			if (routine != null)
				Stop ();
			
			active = true;
			firstTime = true;

			target.OnGetSuccess += CompareSnapshot;

			routine = RefreshCoroutine ();

			target.root.StartCoroutine (routine);
		}

		/// <summary>
		/// Stop the observer.
		/// </summary>
		public void Stop()
		{
			active = false;
			target.OnGetSuccess -= CompareSnapshot;
			lastSnapshot = null;

			if (routine != null) {
				target.root.StopCoroutine (routine);
				routine = null;
			}
				
		}


		IEnumerator RefreshCoroutine()
		{
			while (active) {
				target.GetValue ();
				yield return new WaitForSeconds (refreshRate);
			}
		}
        
		void CompareSnapshot(Firebase dummyVar, DataSnapshot snapshot)
		{
			if (firstTime) {
				firstTime = false;
				lastSnapshot = snapshot;
				return;
			}


			if ((lastSnapshot == null && snapshot != null) || (lastSnapshot != null && !lastSnapshot.RawJson.Equals (snapshot.RawJson))){
				if (OnChange != null)
					OnChange (firebase, snapshot);
			}

			lastSnapshot = snapshot;
		}

		#endregion

	}
}
