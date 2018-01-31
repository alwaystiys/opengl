#version 330 core
out vec4 FragColor;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoord;


struct Material{
    float shininess;
};

uniform Material material;
uniform sampler2D diffuse;
uniform sampler2D specular;
uniform sampler2D emission;

struct Light {
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
uniform Light light;

void main(){
    // ������
    vec3 ambient = light.ambient * vec3(texture(diffuse, TexCoord));

    // ������ 
    vec3 norm = normalize(Normal);
//    vec3 lightDir = normalize(vec3(1.2f, 1.0f, 2.0f) - FragPos);
    vec3 lightDir = normalize(-light.direction);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(diffuse, TexCoord));

    // �����
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * (spec *  vec3(texture(specular, TexCoord)));  
            
    vec3 result = ambient + diffuse + specular;// + texture(emission, TexCoord).rgb;
    FragColor = vec4(result, 1.0);
}