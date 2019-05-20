// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-6343-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB,clip-7736-A,voffset-422-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32052,y:32910,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31812,y:33051,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.735849,c2:0.5868332,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31812,y:32866,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:34a33bb960d573b4994de5bbcff55d63,ntxv:0,isnm:False|UVIN-2441-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32935,y:33527,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6ae9770376d8d8c4984a30cfcf2b0265,ntxv:3,isnm:True|UVIN-9774-UVOUT;n:type:ShaderForge.SFN_Slider,id:358,x:32796,y:32519,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32796,y:32621,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Panner,id:2441,x:31395,y:33269,varname:node_2441,prsc:2,spu:0,spv:-1|UVIN-3083-UVOUT,DIST-4847-OUT;n:type:ShaderForge.SFN_TexCoord,id:3083,x:30714,y:33223,varname:node_3083,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:2134,x:30728,y:33815,varname:node_2134,prsc:2|IN-3414-OUT;n:type:ShaderForge.SFN_Time,id:531,x:30243,y:33861,varname:node_531,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4847,x:31177,y:33558,varname:node_4847,prsc:2|A-9795-R,B-5624-OUT;n:type:ShaderForge.SFN_Slider,id:9200,x:30591,y:34102,ptovrint:False,ptlb:WindIntensity(Panner),ptin:_WindIntensityPanner,varname:_WindIntensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.0274;n:type:ShaderForge.SFN_Multiply,id:7874,x:30979,y:33815,varname:node_7874,prsc:2|A-2134-OUT,B-9200-OUT;n:type:ShaderForge.SFN_Tex2d,id:9795,x:30945,y:33378,ptovrint:False,ptlb:MiddleStatic,ptin:_MiddleStatic,varname:_node_5659_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9ec42946bd73e7a4b821349f78d09d08,ntxv:0,isnm:False|UVIN-3083-UVOUT;n:type:ShaderForge.SFN_Slider,id:7353,x:30152,y:34018,ptovrint:False,ptlb:windSpeed(Panner),ptin:_windSpeedPanner,varname:_windSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.189949,max:5;n:type:ShaderForge.SFN_Multiply,id:3414,x:30507,y:33845,varname:node_3414,prsc:2|A-531-T,B-7353-OUT;n:type:ShaderForge.SFN_Panner,id:9774,x:32722,y:33502,varname:node_9774,prsc:2,spu:0,spv:-1|UVIN-5289-UVOUT,DIST-5754-OUT;n:type:ShaderForge.SFN_TexCoord,id:5289,x:31905,y:33461,varname:node_5289,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:5754,x:32475,y:33714,varname:node_5754,prsc:2|A-2190-R,B-5624-OUT;n:type:ShaderForge.SFN_Tex2d,id:2190,x:32172,y:33604,ptovrint:False,ptlb:MiddleStaticNml,ptin:_MiddleStaticNml,varname:_node_5659_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9ec42946bd73e7a4b821349f78d09d08,ntxv:0,isnm:False|UVIN-5289-UVOUT;n:type:ShaderForge.SFN_Time,id:5048,x:30242,y:33566,varname:node_5048,prsc:2;n:type:ShaderForge.SFN_Vector1,id:8353,x:30227,y:33711,varname:node_8353,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:7476,x:30507,y:33595,varname:node_7476,prsc:2|A-5048-TDB,B-8353-OUT;n:type:ShaderForge.SFN_Multiply,id:5624,x:30979,y:33668,varname:node_5624,prsc:2|A-7801-OUT,B-7874-OUT;n:type:ShaderForge.SFN_Cos,id:7801,x:30728,y:33668,varname:node_7801,prsc:2|IN-7476-OUT;n:type:ShaderForge.SFN_Panner,id:2650,x:30898,y:32322,varname:node_2650,prsc:2,spu:-1,spv:0|UVIN-6950-OUT,DIST-5543-OUT;n:type:ShaderForge.SFN_Tex2d,id:5105,x:31249,y:32401,ptovrint:False,ptlb:Wind Texture,ptin:_WindTexture,varname:node_3347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6562-OUT;n:type:ShaderForge.SFN_Time,id:7938,x:30801,y:32660,varname:node_7938,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5543,x:31007,y:32722,varname:node_5543,prsc:2|A-7938-TTR,B-3705-OUT;n:type:ShaderForge.SFN_Slider,id:3705,x:30705,y:32878,ptovrint:False,ptlb:Wind Speed(Vertex),ptin:_WindSpeedVertex,varname:node_3412,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2665614,max:1;n:type:ShaderForge.SFN_VertexColor,id:3672,x:31249,y:32567,varname:node_3672,prsc:2;n:type:ShaderForge.SFN_Multiply,id:422,x:31686,y:32520,varname:node_422,prsc:2|A-5105-RGB,B-3672-RGB,C-9857-OUT,D-2043-XYZ;n:type:ShaderForge.SFN_Multiply,id:6562,x:31084,y:32418,varname:node_6562,prsc:2|A-2650-UVOUT,B-3279-OUT;n:type:ShaderForge.SFN_Append,id:6950,x:30681,y:32294,varname:node_6950,prsc:2|A-6000-OUT,B-8182-OUT;n:type:ShaderForge.SFN_Dot,id:8182,x:30500,y:32383,varname:node_8182,prsc:2,dt:4|A-8575-OUT,B-7637-G;n:type:ShaderForge.SFN_Normalize,id:2217,x:30270,y:32393,varname:node_2217,prsc:2|IN-1111-X;n:type:ShaderForge.SFN_Normalize,id:8575,x:30270,y:32544,varname:node_8575,prsc:2|IN-1111-Z;n:type:ShaderForge.SFN_Abs,id:5948,x:30150,y:32784,varname:node_5948,prsc:2|IN-2217-OUT;n:type:ShaderForge.SFN_Append,id:4379,x:30353,y:32784,varname:node_4379,prsc:2|A-5948-OUT,B-5676-OUT,C-5676-OUT;n:type:ShaderForge.SFN_Vector1,id:5676,x:30150,y:32911,varname:node_5676,prsc:2,v1:0;n:type:ShaderForge.SFN_Transform,id:2043,x:30552,y:32784,varname:node_2043,prsc:2,tffrom:0,tfto:1|IN-4379-OUT;n:type:ShaderForge.SFN_Slider,id:9857,x:31289,y:32704,ptovrint:False,ptlb:Wind Strength(Vertex),ptin:_WindStrengthVertex,varname:node_9058,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2798384,max:1;n:type:ShaderForge.SFN_Dot,id:6000,x:30500,y:32217,varname:node_6000,prsc:2,dt:4|A-2217-OUT,B-7637-R;n:type:ShaderForge.SFN_ComponentMask,id:7637,x:30270,y:32217,varname:node_7637,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-1533-OUT;n:type:ShaderForge.SFN_Abs,id:1533,x:30081,y:32217,varname:node_1533,prsc:2|IN-1111-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:1111,x:29894,y:32217,varname:node_1111,prsc:2;n:type:ShaderForge.SFN_Slider,id:3279,x:30777,y:32510,ptovrint:False,ptlb:Wind Intensity (Vertex),ptin:_WindIntensityVertex,varname:node_3279,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2931774,max:1;proporder:5964-6665-7736-358-1813-9200-9795-7353-2190-5105-3705-9857-3279;pass:END;sub:END;*/

Shader "Shader Forge/FernSwayPBR3" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Color ("Color", Color) = (0.735849,0.5868332,0,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _WindIntensityPanner ("WindIntensity(Panner)", Range(0, 0.0274)) = 0
        _MiddleStatic ("MiddleStatic", 2D) = "white" {}
        _windSpeedPanner ("windSpeed(Panner)", Range(0, 5)) = 0.189949
        _MiddleStaticNml ("MiddleStaticNml", 2D) = "white" {}
        _WindTexture ("Wind Texture", 2D) = "white" {}
        _WindSpeedVertex ("Wind Speed(Vertex)", Range(0, 1)) = 0.2665614
        _WindStrengthVertex ("Wind Strength(Vertex)", Range(0, 1)) = 0.2798384
        _WindIntensityVertex ("Wind Intensity (Vertex)", Range(0, 1)) = 0.2931774
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
            Cull Off
            
            
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
            uniform float _WindIntensityPanner;
            uniform sampler2D _MiddleStatic; uniform float4 _MiddleStatic_ST;
            uniform float _windSpeedPanner;
            uniform sampler2D _MiddleStaticNml; uniform float4 _MiddleStaticNml_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            uniform float _WindSpeedVertex;
            uniform float _WindStrengthVertex;
            uniform float _WindIntensityVertex;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
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
                float4 vertexColor : COLOR;
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
                o.vertexColor = v.vertexColor;
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
                float4 node_7938 = _Time;
                float node_2217 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7637 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float2 node_6562 = ((float2(0.5*dot(node_2217,node_7637.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7637.g)+0.5)+(node_7938.a*_WindSpeedVertex)*float2(-1,0))*_WindIntensityVertex);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_6562, _WindTexture),0.0,0));
                float node_5676 = 0.0;
                v.vertex.xyz += (_WindTexture_var.rgb*o.vertexColor.rgb*_WindStrengthVertex*mul( unity_WorldToObject, float4(float3(abs(node_2217),node_5676,node_5676),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _MiddleStaticNml_var = tex2D(_MiddleStaticNml,TRANSFORM_TEX(i.uv0, _MiddleStaticNml));
                float4 node_5048 = _Time;
                float4 node_531 = _Time;
                float node_5624 = (cos((node_5048.b*0.4))*(sin((node_531.g*_windSpeedPanner))*_WindIntensityPanner));
                float2 node_9774 = (i.uv0+(_MiddleStaticNml_var.r*node_5624)*float2(0,-1));
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_9774, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _MiddleStatic_var = tex2D(_MiddleStatic,TRANSFORM_TEX(i.uv0, _MiddleStatic));
                float2 node_2441 = (i.uv0+(_MiddleStatic_var.r*node_5624)*float2(0,-1));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2441, _MainTex));
                clip(_MainTex_var.a - 0.5);
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
                float3 diffuseColor = (_MainTex_var.rgb*_Color.rgb); // Need this for specular when using metallic
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
            Cull Off
            
            
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
            uniform float _WindIntensityPanner;
            uniform sampler2D _MiddleStatic; uniform float4 _MiddleStatic_ST;
            uniform float _windSpeedPanner;
            uniform sampler2D _MiddleStaticNml; uniform float4 _MiddleStaticNml_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            uniform float _WindSpeedVertex;
            uniform float _WindStrengthVertex;
            uniform float _WindIntensityVertex;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
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
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7938 = _Time;
                float node_2217 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7637 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float2 node_6562 = ((float2(0.5*dot(node_2217,node_7637.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7637.g)+0.5)+(node_7938.a*_WindSpeedVertex)*float2(-1,0))*_WindIntensityVertex);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_6562, _WindTexture),0.0,0));
                float node_5676 = 0.0;
                v.vertex.xyz += (_WindTexture_var.rgb*o.vertexColor.rgb*_WindStrengthVertex*mul( unity_WorldToObject, float4(float3(abs(node_2217),node_5676,node_5676),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _MiddleStaticNml_var = tex2D(_MiddleStaticNml,TRANSFORM_TEX(i.uv0, _MiddleStaticNml));
                float4 node_5048 = _Time;
                float4 node_531 = _Time;
                float node_5624 = (cos((node_5048.b*0.4))*(sin((node_531.g*_windSpeedPanner))*_WindIntensityPanner));
                float2 node_9774 = (i.uv0+(_MiddleStaticNml_var.r*node_5624)*float2(0,-1));
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_9774, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _MiddleStatic_var = tex2D(_MiddleStatic,TRANSFORM_TEX(i.uv0, _MiddleStatic));
                float2 node_2441 = (i.uv0+(_MiddleStatic_var.r*node_5624)*float2(0,-1));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2441, _MainTex));
                clip(_MainTex_var.a - 0.5);
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
                float3 diffuseColor = (_MainTex_var.rgb*_Color.rgb); // Need this for specular when using metallic
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _WindIntensityPanner;
            uniform sampler2D _MiddleStatic; uniform float4 _MiddleStatic_ST;
            uniform float _windSpeedPanner;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            uniform float _WindSpeedVertex;
            uniform float _WindStrengthVertex;
            uniform float _WindIntensityVertex;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                float4 node_7938 = _Time;
                float node_2217 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7637 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float2 node_6562 = ((float2(0.5*dot(node_2217,node_7637.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7637.g)+0.5)+(node_7938.a*_WindSpeedVertex)*float2(-1,0))*_WindIntensityVertex);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_6562, _WindTexture),0.0,0));
                float node_5676 = 0.0;
                v.vertex.xyz += (_WindTexture_var.rgb*o.vertexColor.rgb*_WindStrengthVertex*mul( unity_WorldToObject, float4(float3(abs(node_2217),node_5676,node_5676),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _MiddleStatic_var = tex2D(_MiddleStatic,TRANSFORM_TEX(i.uv0, _MiddleStatic));
                float4 node_5048 = _Time;
                float4 node_531 = _Time;
                float node_5624 = (cos((node_5048.b*0.4))*(sin((node_531.g*_windSpeedPanner))*_WindIntensityPanner));
                float2 node_2441 = (i.uv0+(_MiddleStatic_var.r*node_5624)*float2(0,-1));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2441, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
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
            uniform float _WindIntensityPanner;
            uniform sampler2D _MiddleStatic; uniform float4 _MiddleStatic_ST;
            uniform float _windSpeedPanner;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            uniform float _WindSpeedVertex;
            uniform float _WindStrengthVertex;
            uniform float _WindIntensityVertex;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                float4 node_7938 = _Time;
                float node_2217 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7637 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float2 node_6562 = ((float2(0.5*dot(node_2217,node_7637.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7637.g)+0.5)+(node_7938.a*_WindSpeedVertex)*float2(-1,0))*_WindIntensityVertex);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_6562, _WindTexture),0.0,0));
                float node_5676 = 0.0;
                v.vertex.xyz += (_WindTexture_var.rgb*o.vertexColor.rgb*_WindStrengthVertex*mul( unity_WorldToObject, float4(float3(abs(node_2217),node_5676,node_5676),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _MiddleStatic_var = tex2D(_MiddleStatic,TRANSFORM_TEX(i.uv0, _MiddleStatic));
                float4 node_5048 = _Time;
                float4 node_531 = _Time;
                float node_5624 = (cos((node_5048.b*0.4))*(sin((node_531.g*_windSpeedPanner))*_WindIntensityPanner));
                float2 node_2441 = (i.uv0+(_MiddleStatic_var.r*node_5624)*float2(0,-1));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2441, _MainTex));
                float3 diffColor = (_MainTex_var.rgb*_Color.rgb);
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
