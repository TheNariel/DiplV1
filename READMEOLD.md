# Dipl V1

**Cellular Neural Networks (CNN)** [[wikipedia]](https://en.wikipedia.org/wiki/Cellular_neural_network)  are a parallel computing paradigm that was first proposed in 1988. Cellular neural networks are similar to neural networks, with the difference that communication is allowed only between neighboring units. Image Processing is one of its applications. CNN processors were designed to perform image processing; specifically, the original application of CNN processors was to perform real-time ultra-high frame-rate (>10,000 frame/s) processing unachievable by digital processors.

![Alt text](/documentation/pic/CnnDia2.PNG?raw=true "neighbours")

This project is the implementation of CNN for the application of Image Processing.

![Alt text](/documentation/pic/CnnDia1.PNG?raw=true "Cnn Architecture")

![Alt text](/documentation/pic/CnnPic3.PNG?raw=true "new state pic")

As shown in the above diagram, imagine a control system with a feedback loop. f(x) is the piece-wise linear sigmoid function. The control (template B) and the feedback (template A) templates (coefficients) are configurable and controls the output of the system. Significant research had been done in determining the templates for common image processing techniques

![Alt text](/documentation/pic/CnnPic1.PNG?raw=true "A/B controls")

More templates are published in this [Template Library](http://cnn-technology.itk.ppke.hu/Template_library_v4.0alpha1.pdf).

**Note**: Not mine (https://github.com/ankitaggarwal011/PyCNN)


![Alt text](/documentation/pic/CnnDia3.PNG?raw=true "new cell state function")

![Alt text](/documentation/pic/CnnDia4.PNG?raw=true "output function")

![Alt text](/documentation/pic/CnnDia5.PNG?raw=true "output graph")


![Alt text](/documentation/pic/CnnPic2.PNG?raw=true "App example")
