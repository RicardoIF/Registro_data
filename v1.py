import sys

document = str(sys.argv[1])

repeat = True
while repeat:
    space = "============================================================================================="
    print("Menu\n\n1)Nuevo registro\n5)Salir\n")
    option = int(input("Opcion: "))
    print(space)

    if option == 1:

        dni = str(input("Cedula: "))
        name = str(input("Nombre: "))
        age = str(input("Edad: "))
        print(space)

        save = int(input("Desea guardar?\n1)Si\n2)No\n\nOpcion: "))

        if save == 1:

            file = open(document, "a")
            file.write("Cedula: " + dni + ", ")
            file.write("Nombre: " + name + ", ")
            file.write("Edad: " + age + "\n")
            file.close()


    if option == 5:
        repeat = False