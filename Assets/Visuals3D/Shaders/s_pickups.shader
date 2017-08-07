// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33376,y:32810,varname:node_4013,prsc:2|diff-7013-RGB,emission-3572-OUT;n:type:ShaderForge.SFN_Color,id:9802,x:32199,y:32896,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9802,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.08088237,c2:1,c3:0.2013186,c4:1;n:type:ShaderForge.SFN_Slider,id:7915,x:32031,y:32723,ptovrint:False,ptlb:Fresnel Brightness,ptin:_FresnelBrightness,varname:node_7915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:120,x:32498,y:32802,varname:node_120,prsc:2|A-7915-OUT,B-9802-RGB;n:type:ShaderForge.SFN_Color,id:7013,x:32351,y:32561,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_7013,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Fresnel,id:2651,x:32269,y:33083,varname:node_2651,prsc:2|NRM-5159-OUT,EXP-2966-OUT;n:type:ShaderForge.SFN_NormalVector,id:5159,x:31986,y:33032,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:2966,x:31898,y:33246,ptovrint:False,ptlb:Fresnel Exponent,ptin:_FresnelExponent,varname:node_2966,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:3572,x:33159,y:32974,varname:node_3572,prsc:2|A-120-OUT,B-6761-OUT,T-2647-OUT;n:type:ShaderForge.SFN_Vector1,id:6761,x:32377,y:33006,varname:node_6761,prsc:2,v1:0;n:type:ShaderForge.SFN_Subtract,id:7291,x:32431,y:33172,varname:node_7291,prsc:2|A-4058-OUT,B-2651-OUT;n:type:ShaderForge.SFN_Vector1,id:4058,x:32149,y:33306,varname:node_4058,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:2647,x:32914,y:33235,varname:node_2647,prsc:2|A-7291-OUT,B-7896-OUT,GT-1292-OUT,EQ-1292-OUT,LT-6317-OUT;n:type:ShaderForge.SFN_Vector1,id:6317,x:32578,y:33385,varname:node_6317,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1292,x:32578,y:33518,varname:node_1292,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7896,x:32578,y:33297,ptovrint:False,ptlb:Fresnel Clamp,ptin:_FresnelClamp,varname:node_7896,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:9802-7915-7013-2966-7896;pass:END;sub:END;*/

Shader "Shader Forge/s_pickups" {
    Properties {
        _Color ("Color", Color) = (0.08088237,1,0.2013186,1)
        _FresnelBrightness ("Fresnel Brightness", Range(1, 5)) = 1
        _Diffuse ("Diffuse", Color) = (0.5,0.5,0.5,1)
        _FresnelExponent ("Fresnel Exponent", Float ) = 1
        _FresnelClamp ("Fresnel Clamp", Float ) = 0.5
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _FresnelBrightness;
            uniform float4 _Diffuse;
            uniform float _FresnelExponent;
            uniform float _FresnelClamp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Diffuse.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_6761 = 0.0;
                float node_2647_if_leA = step((1.0-pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExponent)),_FresnelClamp);
                float node_2647_if_leB = step(_FresnelClamp,(1.0-pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExponent)));
                float node_1292 = 1.0;
                float3 emissive = lerp((_FresnelBrightness*_Color.rgb),float3(node_6761,node_6761,node_6761),lerp((node_2647_if_leA*0.0)+(node_2647_if_leB*node_1292),node_1292,node_2647_if_leA*node_2647_if_leB));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _FresnelBrightness;
            uniform float4 _Diffuse;
            uniform float _FresnelExponent;
            uniform float _FresnelClamp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Diffuse.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
