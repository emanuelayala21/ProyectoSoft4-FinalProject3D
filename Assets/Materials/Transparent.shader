Shader "Custom/ShadowCasterOnly" {
    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        Pass {
            Name "FORWARD"
            Tags {"LightMode"="ForwardBase"}
            ColorMask 0 // No renderiza color
            ZWrite On   // A�n escribe en el depth
        }

        Pass {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }
        }
    }
}
