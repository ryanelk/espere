Shader "Custom/Distortion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        GrabPass { "_BackgroundTexture"}

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Properties
            sampler2D _BackgroundTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                float4 pos = v.vertex;
                float4 originInViewSpace = mul(UNITY_MATRIX_MV, float4(0,0,0,1));
                float4 vertInViewSpace = originInViewSpace + float4(pos.x, pos.z, 0, 0);
                pos = mul(UNITY_MATRIX_P, vertInViewSpace);

                o.vertex = pos;
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                return tex2Dproj(_BackgroundTexture, i.vertex);
            }
            ENDCG
        }
    }
}
