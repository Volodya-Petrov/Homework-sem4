module PointFree

let withoutPointFree x l = List.map (fun y -> y * x) l

// убираем l из входных данных
let pointFree'1 x = List.map (fun y -> y * x)

// убираем x
let pointFree'2 =  List.map << (*)