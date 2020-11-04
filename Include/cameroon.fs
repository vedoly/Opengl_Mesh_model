#define RED vec4(.6, .09, .08, 1.)
#define GREEN vec4(.0, .48, .36, 1.)
#define BACK vec4(.0, .0, .0, 1.)
#define ORANGE vec4(.80, .6, .15, 1.)
#define ORANGE3 vec3(.80, .6, .15)

float polarStar( in vec2 p )
{
    const float pi5 = 0.628318530718; // pi/5
    const float ph2 = 3.2360679775; // 2 * phi
    
    float m2 = mod(atan(p.y, p.x)/pi5 + 1.0, 2.0);
    
    return 5.0 * ph2 * length(p) * cos(pi5 * (m2 - 4.0 * step(1.0, m2) + 1.0)) - 1.0;
}

void mainImage(out vec4 fragColor, in vec2 fragCoord) {
    vec2 lM = vec2(max(iResolution.x, iResolution.y), min(iResolution.x, iResolution.y));
    vec2 pos = (fragCoord - .5 * lM) / lM.x;

    if (abs(pos.y) < .2 && abs(pos.x) < .30){
        if(pos.x < -.1) fragColor = GREEN;
        else if (pos.x > .1) fragColor = ORANGE;
        else fragColor = RED;
    }
    else fragColor = BACK;
    
    // coords
    float px = 2.0/iResolution.y;
	vec2 q = (2.0 * fragCoord - iResolution.xy)/iResolution.y;

    // rotate
    float t = .32;
    q = mat2(cos(t), -sin(t), sin(t), cos(t)) * q;

	// star shape    
	float d = polarStar( q );       

    // colorize
    vec3 col = ORANGE3;
    if(d<.0)
		fragColor = vec4( col, 1.0 );
}
