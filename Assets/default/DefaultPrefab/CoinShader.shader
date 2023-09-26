Shader "Unlit/CoinShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue" = "Transparent"
         }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {

            // ----------中略----------

            fixed4 _Color;

            // ----------中略----------

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
