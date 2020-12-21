import sys

document = str(sys.argv[1])

repeat = True
while repeat:
    space = "============================================================================================="
    print("Menu\n\n1)Nuevo registro\n2)Listar\n3)Buscar\n4)Eliminar\n5)Editar\n6)Salir\n")
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
        
    if option == 2:

        file = open(document, "r")
        print(file.read())
        print(space)
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
    if option == 4:

        file = open(document, "r")
        word = str(input("Ingresar Cedula: "))
        text = file.readlines()

        for line in text:

            if word in line:
                aux = line
                print(aux)
                print(space)
        file.close()

        file = open(document, "w")
        for pos in text:
            
            if pos != aux:
                file.write(pos)
        
        file.close()

    if option == 5:

        file = open(document, "r")
        word = str(input("Ingresar Cedula: "))
        text = file.readlines()

        for line in text:

            if word in line:
                aux = line
                print(aux)
                print(space)
        file.close()

        file = open(document, "w")
        for pos in text:
            
            if pos != aux:
                file.write(pos)
            else:
                dni = str(input("Cedula: "))
                name = str(input("Nombre: "))
                age = str(input("Edad: "))

                file.write("Cedula: " + dni + ", ")
                file.write("Nombre: " + name + ", ")
                file.write("Edad: " + age + "\n")
                print(space)
        
        file.close()

    if option == 6:
        repeat = False