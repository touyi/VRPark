Shader "Custom/TargetPoint"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_BasePoint("BasePoint", Vector) = (0,0,0,0)
		_Range("Range", Range(1,100)) = 1
		_Rate("Rate", float) = 1
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
		    ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 objectPosition : Texcoord0;
			};

			fixed4 _Color;
			float4 _BasePoint;
			int _Range;
			float _Rate;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.objectPosition = v.vertex;
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			    float len = distance(i.objectPosition, _BasePoint);
				// sample the texture
				fixed4 col = _Color;
				col.a = pow(len / max(_Rate, 0.1), _Range);
				col.a = saturate(col.a);
				return col;
			}
			ENDCG
		}
	}
}
