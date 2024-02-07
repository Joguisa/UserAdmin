export interface Users {
    id:              number;
    usuario:         string;
    primerNombre:    string;
    segundoNombre:   string;
    primerApellido:  string;
    segundoApellido: string;
    email:           string;
    idDepartamento:  number;
    idCargo:         number;
    departamento:    General;
    cargo:           General;
}

export interface General {
    id:                number;
    codigo:            string;
    nombre:            string;
    activo:            boolean;
    idUsuarioCreacion: number;
}

export interface AddUsers {
    usuario:            string;
    primerNombre:       string;
    segundoNombre:      string;
    primerApellido:     string;
    segundoApellido:    string;
    email:              string;
    idCargo:            number;
    idDepartamento:     number;
}

export interface EditUsers {
    id?:                number;
    usuario:            string;
    primerNombre:       string;
    segundoNombre:      string;
    primerApellido:     string;
    segundoApellido:    string;
    email:              string;
    idCargo:            number;
    idDepartamento:     number;
}
