// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32987,y:32706,varname:node_3138,prsc:2|emission-9900-OUT,clip-9977-OUT;n:type:ShaderForge.SFN_DepthBlend,id:7304,x:32251,y:33029,varname:node_7304,prsc:2|DIST-7711-OUT;n:type:ShaderForge.SFN_Slider,id:7711,x:31921,y:33029,ptovrint:False,ptlb:distance,ptin:_distance,varname:node_7711,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:5;n:type:ShaderForge.SFN_Color,id:8716,x:32535,y:33195,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_8716,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1172414,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:9301,x:32518,y:32739,varname:node_9301,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:9977,x:32690,y:32934,varname:node_9977,prsc:2|A-9301-OUT,B-7304-OUT;n:type:ShaderForge.SFN_Lerp,id:9900,x:32769,y:33170,varname:node_9900,prsc:2|A-1239-OUT,B-8716-RGB,T-2551-OUT;n:type:ShaderForge.SFN_If,id:2551,x:32565,y:33361,varname:node_2551,prsc:2|A-7304-OUT,B-1376-OUT,GT-8665-OUT,EQ-8665-OUT,LT-1376-OUT;n:type:ShaderForge.SFN_Vector1,id:1376,x:32273,y:33287,varname:node_1376,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8665,x:32301,y:33418,varname:node_8665,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector3,id:1239,x:32535,y:33068,varname:node_1239,prsc:2,v1:1,v2:0,v3:0;proporder:7711-8716;pass:END;sub:END;*/

Shader "Shader Forge/s_influencesphere" {
    Properties {
        _distance ("distance", Range(0, 5)) = 3
        _Color ("Color", Color) = (0.1172414,0,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _distance;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 projPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float node_7304 = saturate((sceneZ-partZ)/_distance);
                clip((1.0-node_7304) - 0.5);
////// Lighting:
////// Emissive:
                float node_1376 = 0.0;
                float node_2551_if_leA = step(node_7304,node_1376);
                float node_2551_if_leB = step(node_1376,node_7304);
                float node_8665 = 1.0;
                float3 emissive = lerp(float3(1,0,0),_Color.rgb,lerp((node_2551_if_leA*node_1376)+(node_2551_if_leB*node_8665),node_8665,node_2551_if_leA*node_2551_if_leB));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _distance;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 projPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float node_7304 = saturate((sceneZ-partZ)/_distance);
                clip((1.0-node_7304) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
