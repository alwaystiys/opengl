
#ifndef APP_TRIANGLE_H
#define APP_TRIANGLE_H

#include "Common/app_callbacks.h"
#include "Common/shader_basic.h"
#include <iostream>





class TriangleShader : public ShaderBasic {
public:
    TriangleShader();
    virtual bool Init();

};


class AppTriangle : public ICallbacks {
public:
    AppTriangle();
    ~AppTriangle();
    virtual bool Init();
    virtual void RenderSceneCB();
private:
    GLuint VBO, VAO;
    TriangleShader* triangleShader;
};


#endif APP_TRIANGLE_H