#version 330
 
in vec2 v_TexCoord;
in vec3 v_Normal;
in vec3 v_FragPos;
uniform sampler2D s_texture;
uniform vec3 v_diffuse;	// OBJ NEW


out vec4 Color;
 
void main()
{
//there are lights here



	vec3 lightColor = vec3(0,1,1);
	vec4 lightAmbient = vec4(0.1, 0.1, 0.1, 1.0);
	vec3 lightPos1 = vec3(0,25,20); //y=10

	//vec lighPos2 = vec(28, 10, -25);
	//vec3 lightColor = vec3(0,1,1);

	//vec lighPos3 = vec(19, 10, -22);
	//vec3 lightColor = vec3(0,1,1);
	
	//vec lighPos4 = vec(-6, 10, 9);
	//vec3 lightColor = vec3(0,1,1);


   //HEX 2 Colors in Vectors


	vec3 norm = normalize(v_Normal);

	vec3 lightDir = normalize(lightPos1 /*+ lightsPos2 + lightsPos3 + lightPos4+.....*/ - v_FragPos); 
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;





    Color = lightAmbient + (vec4(v_diffuse, 1) * texture2D(s_texture, v_TexCoord) * vec4(diffuse, 0));  // OBJ CHANGED
}