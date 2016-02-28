Shader "Unlit/CouloirFou"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		//Blend SrcAlpha OneMinusSrcAlpha
		//Cull Off
		LOD 100

		Pass
		{
			CGPROGRAM
			// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f_perso members vertexClean)
			//#pragma exclude_renderers d3d11 xbox360
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			// structure perso
			struct v2f_perso
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float distance : TEXCOORD1;
				UNITY_FOG_COORDS(1)
			};


			// structure standard
			/*struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};*/

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f_perso vert (appdata v)
			{
				v2f_perso o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				o.distance = distance(float3(v.vertex.xyz), _WorldSpaceCameraPos);
				return o;
			}


			fixed4 frag (v2f_perso i) : COLOR
			{
				fixed4 col;
				float x = i.uv.x;
				float y = i.uv.y;
				float pos = (_Time * 50)%20;
				float largeurMur =  0.2;

				if ((i.distance >= pos) && (i.distance < (pos + largeurMur))) {
					col = float4(0.5, 0.0, 0.0, 1.0);
				}
				else {
				col = float4(0.2, 0.2, 0.2, 1.0);
				}

				UNITY_APPLY_FOG(i.fogCoord, col);				
				return col;
			}
			ENDCG
		}
	}
}
