// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-4405-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32407,y:32978,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Lerp,id:4405,x:31907,y:32543,cmnt:Layer extras on top based on alpha,varname:node_4405,prsc:2|A-2581-RGB,B-7092-RGB,T-5062-OUT;n:type:ShaderForge.SFN_TexCoord,id:9066,x:31079,y:31991,varname:node_9066,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:9987,x:30651,y:32333,varname:node_9987,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:2300,x:30919,y:32545,ptovrint:False,ptlb:Extras1,ptin:_Extras1,varname:node_2300,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7239f283a628612408e48ff6e404f5ea,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:200,x:31298,y:32209,ptovrint:False,ptlb:Base Texture,ptin:_BaseTexture,varname:node_200,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b02f09d6c92952748bdbabff58c2af31,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7092,x:31088,y:32454,varname:node_7092,prsc:2,tex:7239f283a628612408e48ff6e404f5ea,ntxv:0,isnm:False|UVIN-4576-OUT,TEX-2300-TEX;n:type:ShaderForge.SFN_Tex2d,id:2581,x:31500,y:32189,varname:node_2581,prsc:2,tex:b02f09d6c92952748bdbabff58c2af31,ntxv:0,isnm:False|UVIN-4539-OUT,TEX-200-TEX;n:type:ShaderForge.SFN_Multiply,id:4576,x:30892,y:32361,varname:node_4576,prsc:2|A-9987-UVOUT,B-4549-OUT;n:type:ShaderForge.SFN_Multiply,id:4539,x:31347,y:32042,varname:node_4539,prsc:2|A-9066-UVOUT,B-1033-OUT;n:type:ShaderForge.SFN_Slider,id:1033,x:30974,y:32160,ptovrint:False,ptlb:Base Tiling,ptin:_BaseTiling,varname:node_1033,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:2.794885,max:20;n:type:ShaderForge.SFN_Slider,id:4549,x:30573,y:32569,ptovrint:False,ptlb:Extras1 Tiling,ptin:_Extras1Tiling,varname:_BaseTiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:3.882025,max:20;n:type:ShaderForge.SFN_Tex2dAsset,id:9898,x:29853,y:33256,ptovrint:False,ptlb:Masks,ptin:_Masks,varname:node_9898,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4daac7e7b93873f48a47407bf2f7a1ea,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8518,x:30838,y:32826,varname:node_8518,prsc:2,tex:4daac7e7b93873f48a47407bf2f7a1ea,ntxv:0,isnm:False|UVIN-8900-OUT,TEX-9898-TEX;n:type:ShaderForge.SFN_TexCoord,id:1660,x:29771,y:32970,varname:node_1660,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8900,x:30660,y:32807,varname:node_8900,prsc:2|A-1660-UVOUT,B-5252-OUT;n:type:ShaderForge.SFN_Slider,id:5252,x:30280,y:32904,ptovrint:False,ptlb:Extras1 Mask Tiling R,ptin:_Extras1MaskTilingR,varname:_Extras1Tiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.9584844,max:5;n:type:ShaderForge.SFN_Lerp,id:547,x:31297,y:32731,varname:node_547,prsc:2|A-403-OUT,B-7092-A,T-8518-R;n:type:ShaderForge.SFN_Slider,id:2601,x:30243,y:33167,ptovrint:False,ptlb:Extras1 Mask Tiling G,ptin:_Extras1MaskTilingG,varname:_Extras1MaskTilingR_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.418948,max:5;n:type:ShaderForge.SFN_Slider,id:2636,x:30195,y:33445,ptovrint:False,ptlb:Extras1 Mask Tiling B,ptin:_Extras1MaskTilingB,varname:_Extras1MaskTilingG_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.9363525,max:5;n:type:ShaderForge.SFN_Tex2d,id:2158,x:30844,y:33403,varname:_node_9866_copy,prsc:2,tex:4daac7e7b93873f48a47407bf2f7a1ea,ntxv:0,isnm:False|UVIN-9363-OUT,TEX-9898-TEX;n:type:ShaderForge.SFN_Multiply,id:9363,x:30672,y:33344,varname:node_9363,prsc:2|A-1660-UVOUT,B-2636-OUT;n:type:ShaderForge.SFN_Lerp,id:5062,x:31652,y:32956,varname:node_5062,prsc:2|A-403-OUT,B-643-OUT,T-4234-G;n:type:ShaderForge.SFN_Lerp,id:643,x:31488,y:32837,varname:node_643,prsc:2|A-403-OUT,B-547-OUT,T-2158-B;n:type:ShaderForge.SFN_Vector1,id:403,x:31048,y:32963,varname:node_403,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:9742,x:30634,y:33049,varname:node_9742,prsc:2|A-1660-UVOUT,B-2601-OUT;n:type:ShaderForge.SFN_Tex2d,id:4234,x:30844,y:33139,varname:node_4234,prsc:2,tex:4daac7e7b93873f48a47407bf2f7a1ea,ntxv:0,isnm:False|UVIN-9742-OUT,TEX-9898-TEX;proporder:5964-358-1813-2300-200-1033-4549-9898-5252-2601-2636;pass:END;sub:END;*/

Shader "Shader Forge/s_ground" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _Extras1 ("Extras1", 2D) = "white" {}
        _BaseTexture ("Base Texture", 2D) = "white" {}
        _BaseTiling ("Base Tiling", Range(0.1, 20)) = 2.794885
        _Extras1Tiling ("Extras1 Tiling", Range(0.1, 20)) = 3.882025
        _Masks ("Masks", 2D) = "white" {}
        _Extras1MaskTilingR ("Extras1 Mask Tiling R", Range(0.1, 5)) = 0.9584844
        _Extras1MaskTilingG ("Extras1 Mask Tiling G", Range(0.1, 5)) = 1.418948
        _Extras1MaskTilingB ("Extras1 Mask Tiling B", Range(0.1, 5)) = 0.9363525
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _Extras1; uniform float4 _Extras1_ST;
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _BaseTiling;
            uniform float _Extras1Tiling;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float _Extras1MaskTilingR;
            uniform float _Extras1MaskTilingG;
            uniform float _Extras1MaskTilingB;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float2 node_4539 = (i.uv0*_BaseTiling);
                float4 node_2581 = tex2D(_BaseTexture,TRANSFORM_TEX(node_4539, _BaseTexture));
                float2 node_4576 = (i.uv0*_Extras1Tiling);
                float4 node_7092 = tex2D(_Extras1,TRANSFORM_TEX(node_4576, _Extras1));
                float node_403 = 0.0;
                float2 node_8900 = (i.uv0*_Extras1MaskTilingR);
                float4 node_8518 = tex2D(_Masks,TRANSFORM_TEX(node_8900, _Masks));
                float2 node_9363 = (i.uv0*_Extras1MaskTilingB);
                float4 _node_9866_copy = tex2D(_Masks,TRANSFORM_TEX(node_9363, _Masks));
                float2 node_9742 = (i.uv0*_Extras1MaskTilingG);
                float4 node_4234 = tex2D(_Masks,TRANSFORM_TEX(node_9742, _Masks));
                float3 diffuseColor = lerp(node_2581.rgb,node_7092.rgb,lerp(node_403,lerp(node_403,lerp(node_403,node_7092.a,node_8518.r),_node_9866_copy.b),node_4234.g)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _Extras1; uniform float4 _Extras1_ST;
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _BaseTiling;
            uniform float _Extras1Tiling;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float _Extras1MaskTilingR;
            uniform float _Extras1MaskTilingG;
            uniform float _Extras1MaskTilingB;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float2 node_4539 = (i.uv0*_BaseTiling);
                float4 node_2581 = tex2D(_BaseTexture,TRANSFORM_TEX(node_4539, _BaseTexture));
                float2 node_4576 = (i.uv0*_Extras1Tiling);
                float4 node_7092 = tex2D(_Extras1,TRANSFORM_TEX(node_4576, _Extras1));
                float node_403 = 0.0;
                float2 node_8900 = (i.uv0*_Extras1MaskTilingR);
                float4 node_8518 = tex2D(_Masks,TRANSFORM_TEX(node_8900, _Masks));
                float2 node_9363 = (i.uv0*_Extras1MaskTilingB);
                float4 _node_9866_copy = tex2D(_Masks,TRANSFORM_TEX(node_9363, _Masks));
                float2 node_9742 = (i.uv0*_Extras1MaskTilingG);
                float4 node_4234 = tex2D(_Masks,TRANSFORM_TEX(node_9742, _Masks));
                float3 diffuseColor = lerp(node_2581.rgb,node_7092.rgb,lerp(node_403,lerp(node_403,lerp(node_403,node_7092.a,node_8518.r),_node_9866_copy.b),node_4234.g)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _Extras1; uniform float4 _Extras1_ST;
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _BaseTiling;
            uniform float _Extras1Tiling;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float _Extras1MaskTilingR;
            uniform float _Extras1MaskTilingG;
            uniform float _Extras1MaskTilingB;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float2 node_4539 = (i.uv0*_BaseTiling);
                float4 node_2581 = tex2D(_BaseTexture,TRANSFORM_TEX(node_4539, _BaseTexture));
                float2 node_4576 = (i.uv0*_Extras1Tiling);
                float4 node_7092 = tex2D(_Extras1,TRANSFORM_TEX(node_4576, _Extras1));
                float node_403 = 0.0;
                float2 node_8900 = (i.uv0*_Extras1MaskTilingR);
                float4 node_8518 = tex2D(_Masks,TRANSFORM_TEX(node_8900, _Masks));
                float2 node_9363 = (i.uv0*_Extras1MaskTilingB);
                float4 _node_9866_copy = tex2D(_Masks,TRANSFORM_TEX(node_9363, _Masks));
                float2 node_9742 = (i.uv0*_Extras1MaskTilingG);
                float4 node_4234 = tex2D(_Masks,TRANSFORM_TEX(node_9742, _Masks));
                float3 diffColor = lerp(node_2581.rgb,node_7092.rgb,lerp(node_403,lerp(node_403,lerp(node_403,node_7092.a,node_8518.r),_node_9866_copy.b),node_4234.g));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
