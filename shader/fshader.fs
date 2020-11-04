
#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 fragCoord;


void main() {
    vec2 pos = fragCoord;
	
    if (abs(pos.y) < .4 && abs(pos.x) < .5){
        if(pos.x < -.5/3) FragColor = vec4(1.0,0.5,0.2,1);
        else if (pos.x > .5/3) FragColor = vec4(0.9,0.2,0.2,1);
        else FragColor = vec4(1,1,1,1);
    }
    else FragColor = vec4(.0, .0, .0, 1.);
    


}


