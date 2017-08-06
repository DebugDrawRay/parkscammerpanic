// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3422175,fgcg:0.3081747,fgcb:0.3676471,fgca:1,fgde:0.05,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32846,y:32654,varname:node_3138,prsc:2|emission-5724-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32183,y:32491,ptovrint:False,ptlb:BG_Color,ptin:_BG_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:6100,x:31964,y:32780,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_6100,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ee4ddaa8566069c43aac49c677e7d703,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1995,x:32225,y:32688,varname:node_1995,prsc:2,tex:ee4ddaa8566069c43aac49c677e7d703,ntxv:0,isnm:False|UVIN-2053-UVOUT,TEX-6100-TEX;n:type:ShaderForge.SFN_TexCoord,id:2053,x:31733,y:32472,varname:node_2053,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Lerp,id:5724,x:32614,y:32743,varname:node_5724,prsc:2|A-3383-OUT,B-3573-OUT,T-1995-RGB;n:type:ShaderForge.SFN_Multiply,id:3573,x:32389,y:32380,varname:node_3573,prsc:2|A-4283-OUT,B-7241-RGB;n:type:ShaderForge.SFN_Slider,id:3027,x:31686,y:31885,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_3027,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1,max:15;n:type:ShaderForge.SFN_Color,id:7737,x:32372,y:32104,ptovrint:False,ptlb:Text_Color,ptin:_Text_Color,varname:node_7737,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3383,x:32581,y:32281,varname:node_3383,prsc:2|A-7737-RGB,B-4283-OUT;n:type:ShaderForge.SFN_Time,id:987,x:31012,y:31911,varname:node_987,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4283,x:32138,y:31943,varname:node_4283,prsc:2|A-3027-OUT,B-9893-OUT;n:type:ShaderForge.SFN_Sin,id:6912,x:31585,y:32209,varname:node_6912,prsc:2|IN-3224-OUT;n:type:ShaderForge.SFN_Multiply,id:1002,x:31215,y:32189,varname:node_1002,prsc:2|A-987-TTR,B-953-OUT;n:type:ShaderForge.SFN_ValueProperty,id:953,x:30966,y:32267,ptovrint:False,ptlb:Flash speed,ptin:_Flashspeed,varname:node_953,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_Time,id:5965,x:31012,y:32073,varname:node_5965,prsc:2;n:type:ShaderForge.SFN_Add,id:3224,x:31318,y:31978,varname:node_3224,prsc:2|A-1002-OUT,B-5965-TTR;n:type:ShaderForge.SFN_Multiply,id:9893,x:31981,y:32134,varname:node_9893,prsc:2|A-6912-OUT,B-6744-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6744,x:31777,y:32268,ptovrint:False,ptlb:Brightnessmujlt,ptin:_Brightnessmujlt,varname:node_6744,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7241-6100-3027-7737-953-6744;pass:END;sub:END;*/

Shader "Shader Forge/s_billboards" {
    Properties {
        _BG_Color ("BG_Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Mask ("Mask", 2D) = "white" {}
        _Brightness ("Brightness", Range(0.1, 15)) = 1
        _Text_Color ("Text_Color", Color) = (1,1,1,1)
        _Flashspeed ("Flash speed", Float ) = 20
        _Brightnessmujlt ("Brightnessmujlt", Float ) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _BG_Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Brightness;
            uniform float4 _Text_Color;
            uniform float _Flashspeed;
            uniform float _Brightnessmujlt;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_987 = _Time + _TimeEditor;
                float4 node_5965 = _Time + _TimeEditor;
                float node_6912 = sin(((node_987.a*_Flashspeed)+node_5965.a));
                float node_4283 = (_Brightness-(node_6912*_Brightnessmujlt));
                float4 node_1995 = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = lerp((_Text_Color.rgb*node_4283),(node_4283*_BG_Color.rgb),node_1995.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
