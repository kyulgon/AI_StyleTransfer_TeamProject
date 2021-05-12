/*
 * Copyright (c) 2017 VR Stuff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager {
	private static LayerManager instance = null;  // LayerManager를 인스턴스로 만들어서 Dimension에서 가져옴

	public List<string> definedLayers; // List에 string타입으로 변수를 생성
	public static List<Dimension> definedDimensions = new List<Dimension> (); // 차원을 여러개 남을 수 있게 List로 설정ㄴ

	private static int totalLayerNum = 31; // 총 레이어번호를 31로 설정

	public static LayerManager Instance() // Layer를 Instance 메서로 가져와서 넣어주기
	{ 
		if (instance == null) {
			instance = new LayerManager ();
			instance.definedLayers = new List<string> ();
		}
		return instance;
	}

	public int CreateLayer(string name) // CreateLayer를 가져와서 파라미터를 name의 Call by Reference형태를 가짐
	{
		definedLayers.Add (name); // 리스트 값에 파라미터인 name을 추가
	
		// Make physics independant
		for (int i = 0; i < definedLayers.Count; i++)
		{
			for (int j = 0; j < definedLayers.Count; j++)
			{
				if (i == j) continue;
				Physics.IgnoreLayerCollision (totalLayerNum - i - 1, totalLayerNum - j - 1);
			}
		}

		return totalLayerNum - definedLayers.Count;
	}
}
