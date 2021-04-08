Shader "Custom/transparentShader"
{
    Properties
    {
        _Color ("Color", Color) = (.2,.2,1,1)
        _MainTex ("Particle Texture", 2D) = "red" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
       // _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    Category{
        Tags{ "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha One
        Cull Off Lighting Off ZWrite Off Fog {Color (0, 0, 0, 0)}

        BindChannels{
            Bind "Color", color
            Bind "Vertex", vertex
            Bind "TexCoord", texcoord
        }

        SubShader
        {
            Pass{
                SetTexture [_MainTex]{
                    combine texture * primary
                }
            }
        }
    }
    
}
