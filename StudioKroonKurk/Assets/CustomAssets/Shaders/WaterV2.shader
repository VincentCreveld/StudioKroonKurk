// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33139,y:32718,varname:node_2865,prsc:2|diff-8620-OUT,spec-7093-OUT,gloss-3106-OUT,normal-1930-OUT,emission-8948-RGB,alpha-6447-OUT;n:type:ShaderForge.SFN_Vector1,id:7093,x:32955,y:32738,varname:node_7093,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3106,x:32955,y:32793,varname:node_3106,prsc:2,v1:0.8;n:type:ShaderForge.SFN_ValueProperty,id:1361,x:30352,y:32961,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_1361,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_DepthBlend,id:1159,x:30547,y:32961,varname:node_1159,prsc:2|DIST-1361-OUT;n:type:ShaderForge.SFN_Color,id:1985,x:30988,y:32192,ptovrint:False,ptlb:EdgefoamColor,ptin:_EdgefoamColor,varname:node_1985,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Dot,id:7841,x:30352,y:33069,varname:node_7841,prsc:2,dt:4|A-8215-OUT,B-2704-OUT;n:type:ShaderForge.SFN_ViewVector,id:8215,x:30114,y:32978,varname:node_8215,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2704,x:30114,y:33129,prsc:2,pt:False;n:type:ShaderForge.SFN_Divide,id:3145,x:30720,y:33057,varname:node_3145,prsc:2|A-1159-OUT,B-7841-OUT;n:type:ShaderForge.SFN_Clamp01,id:736,x:30925,y:33045,varname:node_736,prsc:2|IN-3145-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3480,x:31137,y:32819,varname:node_3480,prsc:2|IN-736-OUT,IMIN-4646-OUT,IMAX-1679-OUT,OMIN-4784-OUT,OMAX-7633-OUT;n:type:ShaderForge.SFN_Vector1,id:4784,x:30925,y:32929,varname:node_4784,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7633,x:30925,y:32982,varname:node_7633,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:1679,x:30768,y:32857,ptovrint:False,ptlb:FoamMax,ptin:_FoamMax,varname:node_1679,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:4646,x:30768,y:32765,ptovrint:False,ptlb:FoamMin,ptin:_FoamMin,varname:node_4646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3426,x:31785,y:33295,varname:node_3426,prsc:2|IN-736-OUT,IMIN-512-OUT,IMAX-3628-OUT,OMIN-5538-OUT,OMAX-7066-OUT;n:type:ShaderForge.SFN_Slider,id:512,x:30642,y:33241,ptovrint:False,ptlb:DepthMin,ptin:_DepthMin,varname:node_512,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:3628,x:30642,y:33336,ptovrint:False,ptlb:DepthMax,ptin:_DepthMax,varname:node_3628,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:5538,x:30799,y:33424,varname:node_5538,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7066,x:30799,y:33484,varname:node_7066,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:4100,x:31917,y:33002,varname:node_4100,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4140-OUT;n:type:ShaderForge.SFN_Multiply,id:7166,x:32080,y:33012,varname:node_7166,prsc:2|A-4100-OUT,B-1681-OUT;n:type:ShaderForge.SFN_Vector1,id:1681,x:31918,y:33169,varname:node_1681,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:9440,x:32333,y:32997,varname:node_9440,prsc:2|IN-7517-OUT;n:type:ShaderForge.SFN_Clamp01,id:6455,x:31318,y:32819,varname:node_6455,prsc:2|IN-3480-OUT;n:type:ShaderForge.SFN_Multiply,id:3869,x:31759,y:32843,varname:node_3869,prsc:2|A-5724-OUT,B-5523-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5523,x:31382,y:33088,ptovrint:False,ptlb:FoamPower,ptin:_FoamPower,varname:node_5523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Clamp01,id:4140,x:31736,y:33002,varname:node_4140,prsc:2|IN-3869-OUT;n:type:ShaderForge.SFN_Add,id:8072,x:32164,y:32637,varname:node_8072,prsc:2|A-4140-OUT,B-7057-OUT;n:type:ShaderForge.SFN_Clamp01,id:8620,x:32351,y:32575,varname:node_8620,prsc:2|IN-8072-OUT;n:type:ShaderForge.SFN_Add,id:7517,x:32136,y:32866,varname:node_7517,prsc:2|A-7166-OUT,B-3426-OUT;n:type:ShaderForge.SFN_OneMinus,id:3533,x:31334,y:32678,varname:node_3533,prsc:2|IN-6455-OUT;n:type:ShaderForge.SFN_Tex2d,id:4281,x:31182,y:32471,ptovrint:False,ptlb:EdgefoamTexture,ptin:_EdgefoamTexture,varname:node_4281,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8738-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3568,x:31561,y:32580,varname:node_3568,prsc:2|A-4281-RGB,B-7057-OUT;n:type:ShaderForge.SFN_Multiply,id:5724,x:31759,y:32701,varname:node_5724,prsc:2|A-3568-OUT,B-3533-OUT;n:type:ShaderForge.SFN_Panner,id:8738,x:30953,y:32551,varname:node_8738,prsc:2,spu:0.01,spv:0.01|UVIN-2755-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2755,x:30660,y:32367,varname:node_2755,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Color,id:6973,x:30988,y:32001,ptovrint:False,ptlb:WaterColor,ptin:_WaterColor,varname:node_6973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:7057,x:31338,y:32081,varname:node_7057,prsc:2|A-1985-RGB,B-6973-RGB,T-6455-OUT;n:type:ShaderForge.SFN_Multiply,id:6447,x:32516,y:32997,varname:node_6447,prsc:2|A-9440-OUT,B-7203-OUT;n:type:ShaderForge.SFN_Slider,id:7203,x:32265,y:33168,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_7203,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6201266,max:1;n:type:ShaderForge.SFN_Normalize,id:1930,x:33366,y:32251,varname:node_1930,prsc:2|IN-3336-OUT;n:type:ShaderForge.SFN_Lerp,id:3336,x:33179,y:32251,varname:node_3336,prsc:2|A-4178-OUT,B-6536-RGB,T-9460-OUT;n:type:ShaderForge.SFN_Vector3,id:4178,x:32976,y:32019,varname:node_4178,prsc:2,v1:0.7877358,v2:0.9291253,v3:1;n:type:ShaderForge.SFN_Slider,id:9460,x:32844,y:32344,ptovrint:False,ptlb:Reflection,ptin:_Reflection,varname:node_9460,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4938255,max:1;n:type:ShaderForge.SFN_Tex2d,id:6536,x:32976,y:32135,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_6536,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1b9543412f1a9d547b95d68928671d8f,ntxv:3,isnm:True|UVIN-9257-UVOUT;n:type:ShaderForge.SFN_Panner,id:9257,x:32795,y:32135,varname:node_9257,prsc:2,spu:0,spv:-0.01|UVIN-2990-UVOUT,DIST-5917-OUT;n:type:ShaderForge.SFN_TexCoord,id:2990,x:32588,y:32007,varname:node_2990,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:2220,x:32297,y:32116,varname:node_2220,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5917,x:32486,y:32156,varname:node_5917,prsc:2|A-2220-T,B-8187-OUT;n:type:ShaderForge.SFN_Slider,id:8187,x:32121,y:32295,ptovrint:False,ptlb:WaterSpeed,ptin:_WaterSpeed,varname:node_8187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9060695,max:10;n:type:ShaderForge.SFN_Tex2d,id:8948,x:32816,y:33591,ptovrint:False,ptlb:UndercurrentTexture,ptin:_UndercurrentTexture,varname:node_8948,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:598a31a5b05d959479c3e8e32bb9c0e7,ntxv:0,isnm:False|UVIN-6724-UVOUT;n:type:ShaderForge.SFN_Panner,id:6724,x:32633,y:33575,varname:node_6724,prsc:2,spu:0,spv:-0.01|UVIN-8444-UVOUT,DIST-8141-OUT;n:type:ShaderForge.SFN_TexCoord,id:8444,x:32488,y:33394,varname:node_8444,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8141,x:32445,y:33621,varname:node_8141,prsc:2|A-1689-T,B-3585-OUT;n:type:ShaderForge.SFN_Time,id:1689,x:32231,y:33542,varname:node_1689,prsc:2;n:type:ShaderForge.SFN_Slider,id:3585,x:32106,y:33677,ptovrint:False,ptlb:UndercurrentSpeed,ptin:_UndercurrentSpeed,varname:node_3585,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.83739,max:10;n:type:ShaderForge.SFN_FragmentPosition,id:5972,x:30291,y:32557,varname:node_5972,prsc:2;n:type:ShaderForge.SFN_Append,id:560,x:30498,y:32557,varname:node_560,prsc:2|A-5972-Z,B-5972-Y;proporder:1361-1985-1679-4646-5523-512-3628-4281-6973-7203-9460-6536-8187-8948-3585;pass:END;sub:END;*/

Shader "Shader Forge/WaterV2" {
    Properties {
        _Depth ("Depth", Float ) = 10
        _EdgefoamColor ("EdgefoamColor", Color) = (0.1,0,1,1)
        _FoamMax ("FoamMax", Range(0, 1)) = 1
        _FoamMin ("FoamMin", Range(0, 1)) = 0
        _FoamPower ("FoamPower", Float ) = 8
        _DepthMin ("DepthMin", Range(0, 1)) = 0
        _DepthMax ("DepthMax", Range(0, 1)) = 0
        _EdgefoamTexture ("EdgefoamTexture", 2D) = "white" {}
        _WaterColor ("WaterColor", Color) = (1,0,0,1)
        _opacity ("opacity", Range(0, 1)) = 0.6201266
        _Reflection ("Reflection", Range(0, 1)) = 0.4938255
        _Refraction ("Refraction", 2D) = "bump" {}
        _WaterSpeed ("WaterSpeed", Range(0, 10)) = 0.9060695
        _UndercurrentTexture ("UndercurrentTexture", 2D) = "white" {}
        _UndercurrentSpeed ("UndercurrentSpeed", Range(0, 10)) = 3.83739
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _Depth;
            uniform float4 _EdgefoamColor;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _DepthMin;
            uniform float _DepthMax;
            uniform float _FoamPower;
            uniform sampler2D _EdgefoamTexture; uniform float4 _EdgefoamTexture_ST;
            uniform float4 _WaterColor;
            uniform float _opacity;
            uniform float _Reflection;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform float _WaterSpeed;
            uniform sampler2D _UndercurrentTexture; uniform float4 _UndercurrentTexture_ST;
            uniform float _UndercurrentSpeed;
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
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_2220 = _Time;
                float2 node_9257 = (i.uv0+(node_2220.g*_WaterSpeed)*float2(0,-0.01));
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(node_9257, _Refraction)));
                float3 normalLocal = normalize(lerp(float3(0.7877358,0.9291253,1),_Refraction_var.rgb,_Reflection));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.8;
                float perceptualRoughness = 1.0 - 0.8;
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
                float3 specularColor = 0.0;
                float specularMonochrome;
                float4 node_1560 = _Time;
                float2 node_8738 = (i.uv0+node_1560.g*float2(0.01,0.01));
                float4 _EdgefoamTexture_var = tex2D(_EdgefoamTexture,TRANSFORM_TEX(node_8738, _EdgefoamTexture));
                float node_736 = saturate((saturate((sceneZ-partZ)/_Depth)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float node_4784 = 0.0;
                float node_6455 = saturate((node_4784 + ( (node_736 - _FoamMin) * (1.0 - node_4784) ) / (_FoamMax - _FoamMin)));
                float3 node_7057 = lerp(_EdgefoamColor.rgb,_WaterColor.rgb,node_6455);
                float3 node_4140 = saturate((((_EdgefoamTexture_var.rgb*node_7057)*(1.0 - node_6455))*_FoamPower));
                float3 diffuseColor = saturate((node_4140+node_7057)); // Need this for specular when using metallic
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
////// Emissive:
                float4 node_1689 = _Time;
                float2 node_6724 = (i.uv0+(node_1689.g*_UndercurrentSpeed)*float2(0,-0.01));
                float4 _UndercurrentTexture_var = tex2D(_UndercurrentTexture,TRANSFORM_TEX(node_6724, _UndercurrentTexture));
                float3 emissive = _UndercurrentTexture_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_5538 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor,(saturate(((node_4140.r*0.5)+(node_5538 + ( (node_736 - _DepthMin) * (1.0 - node_5538) ) / (_DepthMax - _DepthMin))))*_opacity));
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
            ZWrite Off
            
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
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _Depth;
            uniform float4 _EdgefoamColor;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _DepthMin;
            uniform float _DepthMax;
            uniform float _FoamPower;
            uniform sampler2D _EdgefoamTexture; uniform float4 _EdgefoamTexture_ST;
            uniform float4 _WaterColor;
            uniform float _opacity;
            uniform float _Reflection;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform float _WaterSpeed;
            uniform sampler2D _UndercurrentTexture; uniform float4 _UndercurrentTexture_ST;
            uniform float _UndercurrentSpeed;
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
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_2220 = _Time;
                float2 node_9257 = (i.uv0+(node_2220.g*_WaterSpeed)*float2(0,-0.01));
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(node_9257, _Refraction)));
                float3 normalLocal = normalize(lerp(float3(0.7877358,0.9291253,1),_Refraction_var.rgb,_Reflection));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.8;
                float perceptualRoughness = 1.0 - 0.8;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float4 node_810 = _Time;
                float2 node_8738 = (i.uv0+node_810.g*float2(0.01,0.01));
                float4 _EdgefoamTexture_var = tex2D(_EdgefoamTexture,TRANSFORM_TEX(node_8738, _EdgefoamTexture));
                float node_736 = saturate((saturate((sceneZ-partZ)/_Depth)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float node_4784 = 0.0;
                float node_6455 = saturate((node_4784 + ( (node_736 - _FoamMin) * (1.0 - node_4784) ) / (_FoamMax - _FoamMin)));
                float3 node_7057 = lerp(_EdgefoamColor.rgb,_WaterColor.rgb,node_6455);
                float3 node_4140 = saturate((((_EdgefoamTexture_var.rgb*node_7057)*(1.0 - node_6455))*_FoamPower));
                float3 diffuseColor = saturate((node_4140+node_7057)); // Need this for specular when using metallic
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
                float node_5538 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor * (saturate(((node_4140.r*0.5)+(node_5538 + ( (node_736 - _DepthMin) * (1.0 - node_5538) ) / (_DepthMax - _DepthMin))))*_opacity),0);
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _Depth;
            uniform float4 _EdgefoamColor;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _FoamPower;
            uniform sampler2D _EdgefoamTexture; uniform float4 _EdgefoamTexture_ST;
            uniform float4 _WaterColor;
            uniform sampler2D _UndercurrentTexture; uniform float4 _UndercurrentTexture_ST;
            uniform float _UndercurrentSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_1689 = _Time;
                float2 node_6724 = (i.uv0+(node_1689.g*_UndercurrentSpeed)*float2(0,-0.01));
                float4 _UndercurrentTexture_var = tex2D(_UndercurrentTexture,TRANSFORM_TEX(node_6724, _UndercurrentTexture));
                o.Emission = _UndercurrentTexture_var.rgb;
                
                float4 node_1418 = _Time;
                float2 node_8738 = (i.uv0+node_1418.g*float2(0.01,0.01));
                float4 _EdgefoamTexture_var = tex2D(_EdgefoamTexture,TRANSFORM_TEX(node_8738, _EdgefoamTexture));
                float node_736 = saturate((saturate((sceneZ-partZ)/_Depth)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float node_4784 = 0.0;
                float node_6455 = saturate((node_4784 + ( (node_736 - _FoamMin) * (1.0 - node_4784) ) / (_FoamMax - _FoamMin)));
                float3 node_7057 = lerp(_EdgefoamColor.rgb,_WaterColor.rgb,node_6455);
                float3 node_4140 = saturate((((_EdgefoamTexture_var.rgb*node_7057)*(1.0 - node_6455))*_FoamPower));
                float3 diffColor = saturate((node_4140+node_7057));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float roughness = 1.0 - 0.8;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
