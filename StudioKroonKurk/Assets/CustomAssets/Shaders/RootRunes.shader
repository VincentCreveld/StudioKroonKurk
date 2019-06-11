// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33027,y:32723,varname:node_2865,prsc:2|diff-9630-OUT,spec-358-OUT,gloss-1813-OUT,normal-5107-OUT,emission-6250-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:31153,y:32586,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:30802,y:32548,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:30802,y:32293,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32130,y:32876,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32494,y:32773,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32494,y:32896,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Tex2d,id:6680,x:31852,y:33111,ptovrint:False,ptlb:LightVeinTex,ptin:_LightVeinTex,varname:node_6680,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:05f26bc8534721d4bbc47251cd48bcbd,ntxv:3,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:9313,x:31225,y:33443,varname:node_9313,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Color,id:760,x:31852,y:33328,ptovrint:False,ptlb:Color_Lightvein,ptin:_Color_Lightvein,varname:node_760,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4672,x:32226,y:33431,varname:node_4672,prsc:2|A-5024-RGB,B-1143-OUT;n:type:ShaderForge.SFN_Tex2d,id:5024,x:31852,y:33517,ptovrint:False,ptlb:PulseTex,ptin:_PulseTex,varname:node_5024,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4c02eee28bd355c488ecfbc9470d4815,ntxv:0,isnm:False|UVIN-7423-UVOUT;n:type:ShaderForge.SFN_Panner,id:7423,x:31639,y:33551,varname:node_7423,prsc:2,spu:0,spv:1|UVIN-9313-UVOUT,DIST-8162-OUT;n:type:ShaderForge.SFN_Time,id:544,x:31225,y:33603,varname:node_544,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8162,x:31404,y:33642,varname:node_8162,prsc:2|A-544-T,B-8455-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1143,x:32026,y:33585,ptovrint:False,ptlb:pulseSpeed,ptin:_pulseSpeed,varname:node_1143,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Blend,id:6250,x:32674,y:33290,varname:node_6250,prsc:2,blmd:14,clmp:True|SRC-8400-OUT,DST-4672-OUT;n:type:ShaderForge.SFN_Multiply,id:8400,x:32142,y:33281,varname:node_8400,prsc:2|A-6680-A,B-760-RGB;n:type:ShaderForge.SFN_ValueProperty,id:8455,x:31236,y:33846,ptovrint:False,ptlb:PulseDirection,ptin:_PulseDirection,varname:node_8455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.346;n:type:ShaderForge.SFN_Lerp,id:5107,x:32557,y:33010,varname:node_5107,prsc:2|A-5964-RGB,B-361-RGB,T-5950-OUT;n:type:ShaderForge.SFN_Tex2d,id:361,x:32130,y:33065,ptovrint:False,ptlb:MudNormal,ptin:_MudNormal,varname:node_6862,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:3063,x:30287,y:32953,ptovrint:False,ptlb:UpNode_copy,ptin:_UpNode_copy,varname:_UpNode_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.975541,max:1;n:type:ShaderForge.SFN_Vector1,id:270,x:30475,y:32795,varname:node_270,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:761,x:30675,y:32830,varname:node_761,prsc:2|A-270-OUT,B-3063-OUT,C-270-OUT;n:type:ShaderForge.SFN_Dot,id:53,x:30913,y:32814,varname:node_53,prsc:2,dt:1|A-761-OUT,B-6749-XYZ;n:type:ShaderForge.SFN_NormalVector,id:7975,x:30675,y:33015,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9516,x:31107,y:32814,varname:node_9516,prsc:2|A-53-OUT,B-8040-OUT;n:type:ShaderForge.SFN_Slider,id:8040,x:30536,y:33229,ptovrint:False,ptlb:Level_copy,ptin:_Level_copy,varname:_Level_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.726853,max:10;n:type:ShaderForge.SFN_Slider,id:3065,x:30536,y:33379,ptovrint:False,ptlb:Contrast_copy,ptin:_Contrast_copy,varname:_Contrast_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.019784,max:25;n:type:ShaderForge.SFN_Power,id:2752,x:31310,y:32814,varname:node_2752,prsc:2|VAL-9516-OUT,EXP-3065-OUT;n:type:ShaderForge.SFN_Clamp01,id:5950,x:31510,y:32814,varname:node_5950,prsc:2|IN-2752-OUT;n:type:ShaderForge.SFN_Tex2d,id:3882,x:31248,y:32365,ptovrint:False,ptlb:MudDiffuse_copy,ptin:_MudDiffuse_copy,varname:_MudDiffuse_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3bd532677ed62ae498a69d7e954d9e01,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:788,x:31590,y:32374,varname:node_788,prsc:2|A-3882-RGB,B-9413-RGB;n:type:ShaderForge.SFN_Color,id:9413,x:31208,y:32105,ptovrint:False,ptlb:Mud_Color,ptin:_Mud_Color,varname:_Mud_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9320468,c3:0,c4:1;n:type:ShaderForge.SFN_FragmentPosition,id:6749,x:30500,y:33028,varname:node_6749,prsc:2;n:type:ShaderForge.SFN_Lerp,id:9630,x:31823,y:32635,varname:node_9630,prsc:2|A-6343-OUT,B-788-OUT,T-5950-OUT;proporder:5964-6665-7736-358-1813-6680-760-5024-1143-8455-361-3063-8040-3065-3882-9413;pass:END;sub:END;*/

Shader "Shader Forge/RootRunes" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Color ("Color", Color) = (0.5019608,0.5019608,0.5019608,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _LightVeinTex ("LightVeinTex", 2D) = "bump" {}
        _Color_Lightvein ("Color_Lightvein", Color) = (0.5,0.5,0.5,1)
        _PulseTex ("PulseTex", 2D) = "white" {}
        _pulseSpeed ("pulseSpeed", Float ) = 1
        _PulseDirection ("PulseDirection", Float ) = 1.346
        _MudNormal ("MudNormal", 2D) = "bump" {}
        _UpNode_copy ("UpNode_copy", Range(-1, 1)) = 0.975541
        _Level_copy ("Level_copy", Range(0, 10)) = 2.726853
        _Contrast_copy ("Contrast_copy", Range(0, 25)) = 1.019784
        _MudDiffuse_copy ("MudDiffuse_copy", 2D) = "white" {}
        _Mud_Color ("Mud_Color", Color) = (1,0.9320468,0,1)
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _LightVeinTex; uniform float4 _LightVeinTex_ST;
            uniform float4 _Color_Lightvein;
            uniform sampler2D _PulseTex; uniform float4 _PulseTex_ST;
            uniform float _pulseSpeed;
            uniform float _PulseDirection;
            uniform sampler2D _MudNormal; uniform float4 _MudNormal_ST;
            uniform float _UpNode_copy;
            uniform float _Level_copy;
            uniform float _Contrast_copy;
            uniform sampler2D _MudDiffuse_copy; uniform float4 _MudDiffuse_copy_ST;
            uniform float4 _Mud_Color;
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
                float3 _MudNormal_var = UnpackNormal(tex2D(_MudNormal,TRANSFORM_TEX(i.uv0, _MudNormal)));
                float node_270 = 0.0;
                float node_5950 = saturate(pow((max(0,dot(float3(node_270,_UpNode_copy,node_270),i.posWorld.rgb))*_Level_copy),_Contrast_copy));
                float3 normalLocal = lerp(_BumpMap_var.rgb,_MudNormal_var.rgb,node_5950);
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _MudDiffuse_copy_var = tex2D(_MudDiffuse_copy,TRANSFORM_TEX(i.uv0, _MudDiffuse_copy));
                float3 node_788 = (_MudDiffuse_copy_var.rgb*_Mud_Color.rgb);
                float3 node_9630 = lerp(node_6343,node_788,node_5950);
                float3 diffuseColor = node_9630; // Need this for specular when using metallic
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
                float4 _LightVeinTex_var = tex2D(_LightVeinTex,TRANSFORM_TEX(i.uv0, _LightVeinTex));
                float4 node_544 = _Time;
                float2 node_7423 = (i.uv0+(node_544.g*_PulseDirection)*float2(0,1));
                float4 _PulseTex_var = tex2D(_PulseTex,TRANSFORM_TEX(node_7423, _PulseTex));
                float3 emissive = saturate(( (_LightVeinTex_var.a*_Color_Lightvein.rgb) > 0.5 ? ((_PulseTex_var.rgb*_pulseSpeed) + 2.0*(_LightVeinTex_var.a*_Color_Lightvein.rgb) -1.0) : ((_PulseTex_var.rgb*_pulseSpeed) + 2.0*((_LightVeinTex_var.a*_Color_Lightvein.rgb)-0.5))));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _LightVeinTex; uniform float4 _LightVeinTex_ST;
            uniform float4 _Color_Lightvein;
            uniform sampler2D _PulseTex; uniform float4 _PulseTex_ST;
            uniform float _pulseSpeed;
            uniform float _PulseDirection;
            uniform sampler2D _MudNormal; uniform float4 _MudNormal_ST;
            uniform float _UpNode_copy;
            uniform float _Level_copy;
            uniform float _Contrast_copy;
            uniform sampler2D _MudDiffuse_copy; uniform float4 _MudDiffuse_copy_ST;
            uniform float4 _Mud_Color;
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
                float3 _MudNormal_var = UnpackNormal(tex2D(_MudNormal,TRANSFORM_TEX(i.uv0, _MudNormal)));
                float node_270 = 0.0;
                float node_5950 = saturate(pow((max(0,dot(float3(node_270,_UpNode_copy,node_270),i.posWorld.rgb))*_Level_copy),_Contrast_copy));
                float3 normalLocal = lerp(_BumpMap_var.rgb,_MudNormal_var.rgb,node_5950);
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _MudDiffuse_copy_var = tex2D(_MudDiffuse_copy,TRANSFORM_TEX(i.uv0, _MudDiffuse_copy));
                float3 node_788 = (_MudDiffuse_copy_var.rgb*_Mud_Color.rgb);
                float3 node_9630 = lerp(node_6343,node_788,node_5950);
                float3 diffuseColor = node_9630; // Need this for specular when using metallic
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _LightVeinTex; uniform float4 _LightVeinTex_ST;
            uniform float4 _Color_Lightvein;
            uniform sampler2D _PulseTex; uniform float4 _PulseTex_ST;
            uniform float _pulseSpeed;
            uniform float _PulseDirection;
            uniform float _UpNode_copy;
            uniform float _Level_copy;
            uniform float _Contrast_copy;
            uniform sampler2D _MudDiffuse_copy; uniform float4 _MudDiffuse_copy_ST;
            uniform float4 _Mud_Color;
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
                
                float4 _LightVeinTex_var = tex2D(_LightVeinTex,TRANSFORM_TEX(i.uv0, _LightVeinTex));
                float4 node_544 = _Time;
                float2 node_7423 = (i.uv0+(node_544.g*_PulseDirection)*float2(0,1));
                float4 _PulseTex_var = tex2D(_PulseTex,TRANSFORM_TEX(node_7423, _PulseTex));
                o.Emission = saturate(( (_LightVeinTex_var.a*_Color_Lightvein.rgb) > 0.5 ? ((_PulseTex_var.rgb*_pulseSpeed) + 2.0*(_LightVeinTex_var.a*_Color_Lightvein.rgb) -1.0) : ((_PulseTex_var.rgb*_pulseSpeed) + 2.0*((_LightVeinTex_var.a*_Color_Lightvein.rgb)-0.5))));
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _MudDiffuse_copy_var = tex2D(_MudDiffuse_copy,TRANSFORM_TEX(i.uv0, _MudDiffuse_copy));
                float3 node_788 = (_MudDiffuse_copy_var.rgb*_Mud_Color.rgb);
                float node_270 = 0.0;
                float node_5950 = saturate(pow((max(0,dot(float3(node_270,_UpNode_copy,node_270),i.posWorld.rgb))*_Level_copy),_Contrast_copy));
                float3 node_9630 = lerp(node_6343,node_788,node_5950);
                float3 diffColor = node_9630;
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
