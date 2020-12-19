import sys

document = str(sys.argv[1])

repeat = True
while repeat:
    space = "============================================================================================="
    print("Menu\n\n1)Nuevo registro\n)2Listar\n3)Buscar\n5)Salir\n")
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
            file.write(space + "\n")
            file.close()
        
    if option == 2:

        file = open(document, "r")
        print(file.read())
        file.close()
        
    if option == 3:

        file = open(document, "r")
        word = str(input("Ingrese la cedula: "))

        ocurrens = []
        for line in file:

            line = line.rstrip()

            if word in line:
                ocurrens.append(line)
                print(ocurrens)
        
        print(space)

    if option == 5:
        repeat = False