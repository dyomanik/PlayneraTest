# PlayneraTest
Тестовое задание в Playnera на должность Junior Unity разработчик. 


Реализация задания:
1. Скрипт DragAndDrop устанавливается на перемещаемый объект (apple). Полки и пол (standSurfaces) располагаются на отдельном маске слоя(LayerMask).При нажатии на объект он отслеживает положение курсора, перемещает объект на передний план. При отпускании курсора объект перемещается на второй план, переключается на динамический режим rigibody, проводится проверка на касание с поверхностью. Если есть касания с наобходимой поверхностью, то объект переключается в кинематический режим rigibody.
2. Для перемещения камеры скрипт CameraScrolling устанавливается на MainCamera. Отслеживается движение курсора и при перемещении его в зону границы экрана (граница определяется через параметр edgeThreshold в инспекторе) задаём вектор направления движения камеры в нужную сторону. После чего ограничиваем движение камеры не далее границы сцены и задаём новое положение камеры. 
