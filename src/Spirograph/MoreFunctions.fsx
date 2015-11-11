// Bryony's children 

//  bob     = 2
//  sam     = 4
//  jon     = 7
//  sarah   = 8

let childAges = (2,4,7,8)

let addChildAges ages =
    let bob, sam, jon, sarah = ages
    bob + sam + jon + sarah

let roomAge bob =
    let addBobsAge sam =
        let addSamsAge jon =
            let addJonsAge sarah =
                bob + sam + jon + sarah
            addJonsAge
        addSamsAge
    addBobsAge

let addAges bob sam jon sarah =
    bob + sam + jon + sarah

let triArea height width =
    (height * width) / 2
