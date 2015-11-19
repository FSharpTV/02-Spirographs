let person = ("Mark","Gray","Man Utd", 22)

type Date = {day:int;month:int;year:int}

type Person = {
    firstName: string
    lastName: string
    favClub: string
    myAge: int
    dateOfBirth: Date }

let me = { 
    firstName="Mark"
    lastName="Gray"
    favClub ="Man Utd"
    myAge=22
    dateOfBirth={day=1;month=1;year=1900} }

let updateDob person birthday =
    let updated = { person with dateOfBirth=birthday }
    printfn "%A" updated
    printfn "%A" person
    updated

let { firstName=myFirstName } = me
let { lastName=myLastName } = me
let { myAge=myAge } = me
let { favClub=myClub } = me

let myFullName = me.firstName + " " + me.lastName

let temp = { me with myAge=30 }
