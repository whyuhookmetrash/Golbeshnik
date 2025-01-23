Shader "Custom/LineShader"
{
    SubShader
    {
        Pass
        {
            ZWrite Off
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha
            
            // Указываем цвет линий (красный)
            Color (1, 0, 0, 1) // Красный цвет линий
        }
    }
}