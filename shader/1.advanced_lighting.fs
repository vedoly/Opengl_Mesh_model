#version 330 core
out vec4 FragColor;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
} fs_in;

uniform sampler2D floorTexture;
uniform vec3 lightPos;
uniform vec3 lightPosLeft;
uniform vec3 lightPosRight;
uniform vec3 viewPos;
uniform bool blinn;
uniform bool blinnM;
uniform bool blinnR;

void main()
{           
    vec3 color = texture(floorTexture, fs_in.TexCoords).rgb;
    // ambient
    vec3 ambient = 0.05 * color;
    // diffuse
    vec3 lightDir = normalize(lightPos + vec3(-1,0,0) - fs_in.FragPos);
    vec3 normal = normalize(fs_in.Normal);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * color + 0.1;
    // specular
    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = 0.0;
    if(blinn)
    {
        vec3 halfwayDir = normalize(lightDir + viewDir);  
        spec = pow(max(dot(normal, halfwayDir), 0.0), 32.0);
    }
    else
    {
        vec3 reflectDir = reflect(-lightDir, normal);
        spec = pow(max(dot(viewDir, reflectDir), 0.0), 8.0);
    }
    vec3 specular = vec3(1,0,0) * spec; // assuming bright white light color
   
    ////////////////////////////////////////////////////////////////////////////////////


    vec3 lightDir2 = normalize(lightPos + vec3(0,0,0) - fs_in.FragPos);
    vec3 normal2 = normalize(fs_in.Normal);
    float diff2 = max(dot(lightDir2, normal2), 0.0);
    vec3 diffuse2 = diff2 * color + 0.1;
    // specular
    
    vec3 reflectDir2 = reflect(-lightDir2, normal2);
    float spec2 = 0.0;
    if(blinnM)
    {
        vec3 halfwayDir2 = normalize(lightDir2 + viewDir);  
        spec2 = pow(max(dot(normal2, halfwayDir2), 0.0), 32.0);
    }
    else
    {
        vec3 reflectDir2 = reflect(-lightDir2, normal2);
        spec2 = pow(max(dot(viewDir, reflectDir2), 0.0), 8.0);
    }
    vec3 specular2 = vec3(0,1,0) * spec2; // assuming bright white light color
    FragColor = vec4(ambient + diffuse + specular + diffuse2 + specular2, 1.0);


    vec3 lightDir3 = normalize(lightPos + vec3(1,0,0)  - fs_in.FragPos);
    vec3 normal3 = normalize(fs_in.Normal);
    float diff3 = max(dot(lightDir3, normal3), 0.0);
    vec3 diffuse3 = diff3 * color + 0.1;
    // specular
    
    vec3 reflectDir3 = reflect(-lightDir3, normal3);
    float spec3 = 0.0;
    if(blinnR)
    {
        vec3 halfwayDir3 = normalize(lightDir3 + viewDir);  
        spec3 = pow(max(dot(normal3, halfwayDir3), 0.0), 32.0);
    }
    else
    {
        vec3 reflectDir3 = reflect(-lightDir3, normal3);
        spec3 = pow(max(dot(viewDir, reflectDir3), 0.0), 8.0);
    }
    vec3 specular3 = vec3(0, 0, 1) * spec3; // assuming bright white light color
    FragColor = vec4(ambient  + specular + diffuse*0.7 + specular2 + specular3 , 1.0);

    






}