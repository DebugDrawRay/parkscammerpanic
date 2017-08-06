// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33193,y:32945,varname:node_3138,prsc:2|emission-8610-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32036,y:32952,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6141,x:32119,y:32697,varname:node_6141,prsc:2,tex:c0943a954d4c1b544ba011726b1c4ba9,ntxv:0,isnm:False|TEX-7236-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7236,x:31863,y:32720,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_7236,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c0943a954d4c1b544ba011726b1c4ba9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:843,x:32262,y:32559,ptovrint:False,ptlb:Emission mask,ptin:_Emissionmask,varname:node_843,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ab80db7918ec1d54a9ac5f3edb3f392e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Dot,id:2129,x:32086,y:33142,varname:node_2129,prsc:2,dt:4|A-7924-OUT,B-2788-OUT;n:type:ShaderForge.SFN_ViewVector,id:7924,x:31836,y:33166,varname:node_7924,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2788,x:31866,y:33308,prsc:2,pt:False;n:type:ShaderForge.SFN_If,id:8610,x:32969,y:32962,varname:node_8610,prsc:2|A-2129-OUT,B-536-OUT,GT-1338-OUT,EQ-1338-OUT,LT-8789-OUT;n:type:ShaderForge.SFN_Vector1,id:536,x:32150,y:33313,varname:node_536,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:8789,x:32120,y:33412,varname:node_8789,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:6187,x:32446,y:32768,varname:node_6187,prsc:2|A-6141-RGB,B-866-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8126,x:32050,y:32870,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_8126,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:866,x:32310,y:32926,varname:node_866,prsc:2|A-8126-OUT,B-7241-RGB;n:type:ShaderForge.SFN_Lerp,id:1338,x:32746,y:32636,varname:node_1338,prsc:2|A-9072-OUT,B-6187-OUT,T-7949-RGB;n:type:ShaderForge.SFN_Tex2d,id:7949,x:32446,y:32560,varname:node_7949,prsc:2,tex:ab80db7918ec1d54a9ac5f3edb3f392e,ntxv:0,isnm:False|TEX-843-TEX;n:type:ShaderForge.SFN_Vector1,id:9072,x:32615,y:32529,varname:node_9072,prsc:2,v1:0;proporder:7241-7236-8126-843;pass:END;sub:END;*/

Shader "Shader Forge/s_windowsdoors" {
    Properties {
        _EmissionColor ("EmissionColor", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Texture ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Float ) = 2
        _Emissionmask ("Emission mask", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _EmissionColor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _Emissionmask; uniform float4 _Emissionmask_ST;
            uniform float _Brightness;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_8610_if_leA = step(0.5*dot(viewDirection,i.normalDir)+0.5,0.5);
                float node_8610_if_leB = step(0.5,0.5*dot(viewDirection,i.normalDir)+0.5);
                float node_9072 = 0.0;
                float4 node_6141 = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float4 node_7949 = tex2D(_Emissionmask,TRANSFORM_TEX(i.uv0, _Emissionmask));
                float3 node_1338 = lerp(float3(node_9072,node_9072,node_9072),(node_6141.rgb*(_Brightness*_EmissionColor.rgb)),node_7949.rgb);
                float3 emissive = lerp((node_8610_if_leA*0.0)+(node_8610_if_leB*node_1338),node_1338,node_8610_if_leA*node_8610_if_leB);
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
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
