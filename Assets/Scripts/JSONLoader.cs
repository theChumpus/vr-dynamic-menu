using UnityEngine;
using System.Collections;

public class JSONLoader : MonoBehaviour
{

	public GameObject videoSpherePrefab;
	public string baseUrl;

	string videoUrlKey = "videoUrl";
	string imageUrlKey = "imageUrl";

	IEnumerator Start () {

		WWW www = new WWW (baseUrl + "/videos.json");
		yield return www;
		JSONObject videos = new JSONObject (www.text);

		float rotation = 0f;
		float y = 0f;

		for (int i = 0; i < videos.list.Count; i++) {

			float radius = 5f;
			float radians = Mathf.Deg2Rad *  rotation;
			float x = radius * Mathf.Sin (radians);
			float z = radius * Mathf.Cos (radians);
			Vector3 pos = new Vector3 (x, y, z);

			GameObject videoSphere = Instantiate (videoSpherePrefab, pos, Quaternion.identity) as GameObject;

			JSONObject obj = videos.list [i];
			string imageUrl = baseUrl + obj[imageUrlKey].str;
			StartCoroutine(LoadImageTexture (videoSphere, imageUrl));

			rotation += 30f;
			// If we've run out of room, quit the loop. Todo: change y position to add more spheres
			if (rotation % 360f == 0f) {
				break;
			}
		}
	}

	IEnumerator LoadImageTexture(GameObject obj, string url) {
		WWW request = new WWW (url);
		yield return request;
		obj.GetComponent<Renderer> ().material.mainTexture = request.texture;
	}
}
