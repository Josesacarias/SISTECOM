<template>
    <v-layout align-start>
        <v-flex>
            <v-toolbar flat color="white">
                <v-toolbar-title>Nueva Solicitud</v-toolbar-title>
                    <v-divider
                    class="mx-2"
                    inset
                    vertical
                    ></v-divider>
                    <v-spacer></v-spacer>
                    <v-text-field class="text-xs-center" v-model="search" append-icon="search" label="Búsqueda" single-line hide-details></v-text-field>
                    <v-spacer></v-spacer>
                    <v-dialog v-model="dialog" max-width="800px">
                        <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
                        <v-card>
                            <v-card-title>
                            <span class="headline">{{ formTitle }}</span>
                            </v-card-title>
                
                            <v-card-text>
                            <v-container grid-list-md>
                                <v-layout wrap>
                                <v-flex xs12 sm6 md6>
                                    <v-text-field label="codigo">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm6 md6>
                                    <v-text-field type="date" label="Fecha de Registro">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm6 md6>
                                    <v-text-field  label="Nombre de Solicitud">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm6 md6>
                                    <v-select 
                                     label="Nombre Solicitante">
                                    </v-select>
                                </v-flex>

                                   <v-flex xs12 sm6 md6>
                                    <v-text-field  label="DPI Solicitante">
                                    </v-text-field>
                                </v-flex>

                                 <v-flex xs12 sm6 md6>
                                    <v-text-field  type="date" label="Fecha de Entrega">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm6 md6>
                                    <v-text-field  type="date" label="Fecha de Solicitud">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm6 md6>
                                    <v-text-field  type="number" label="Cantidad">
                                    </v-text-field>
                                </v-flex>

                                
                                <v-flex xs12 sm12 md12>
                                    <v-text-field   label="Descripcion">
                                    </v-text-field>
                                </v-flex>

                                <v-flex xs12 sm12 md12 v-show="valida">
                                    <div class="red--text" v-for="v in validaMensaje" :key="v" v-text="v">
                                    </div>
                                </v-flex>
                                </v-layout>
                            </v-container>
                            </v-card-text>
                
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
                                <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                    <v-dialog v-model="adModal" max-width="290">
                        <v-card>
                            <v-card-title class="headline" v-if="adAccion==1">¿Activar Item?</v-card-title>
                            <v-card-title class="headline" v-if="adAccion==2">¿Desactivar Item?</v-card-title>
                            <v-card-text>
                                Estás a punto de 
                                <span v-if="adAccion==1">Activar </span>
                                <span v-if="adAccion==2">Desactivar </span>
                                el ítem {{ adNombre }}
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="green darken-1" flat="flat" @click="activarDesactivarCerrar">
                                    Cancelar
                                </v-btn>
                                <v-btn v-if="adAccion==1" color="orange darken-4" flat="flat" @click="activar">
                                    Activar
                                </v-btn>
                                <v-btn v-if="adAccion==2" color="orange darken-4" flat="flat" @click="desactivar">
                                    Desactivar
                                </v-btn>
                            </v-card-actions>

                        </v-card>
                    </v-dialog>
                </v-toolbar>
            <v-data-table
                :headers="headers"
                :items="solicitud"
                :search="search"
                class="elevation-1"
            >
                <template slot="items" slot-scope="props">
                    <td class="justify-center layout px-0">
                        <v-icon
                        small
                        class="mr-2"
                        @click="editItem(props.item)"
                        >
                        edit
                        </v-icon>
                        <template v-if="props.item.condicion">
                            <v-icon
                            small
                            @click="activarDesactivarMostrar(2,props.item)"
                            >
                            block
                            </v-icon>
                        </template>
                        <template v-else>
                            <v-icon
                            small
                            @click="activarDesactivarMostrar(1,props.item)"
                            >
                            check
                            </v-icon>
                        </template>
                    </td>
                    <td>{{ props.item.codigo }}</td>
                    <td>{{ props.item.fecha_registro }}</td>
                    <td>{{ props.item.nombre_solicitud }}</td>
                    <td>{{ props.item.nombre_solicitante }}</td>
                    <td>{{ props.item.dpi }}</td>
                    <td>{{ props.item.fecha_entrega }}</td>
                    <td>{{ props.item.fecha_solicitd }}</td>
                    <td>{{ props.item.cantidad }}</td>
                    <td>{{ props.item.descripcion }}</td>
                    <td>
                        <div v-if="props.item.condicion">
                            <span class="blue--text">Activo</span>
                        </div>
                        <div v-else>
                            <span class="red--text">Inactivo</span>
                        </div>
                    </td>
                </template>
                <template slot="no-data">
                <v-btn color="primary" @click="listar">Resetear</v-btn>
                </template>
            </v-data-table>
        </v-flex>
    </v-layout>
</template>
<script>
    import axios from 'axios'
    export default {
        data(){
            return {
                solicitud:[],                
                dialog: false,
                headers: [
                    { text: 'Opciones', value: 'opciones', sortable: false },
                    { text: 'Codigo', value: 'codigo' },
                    { text: 'Fecha Registro', value: 'fecha_registro' },
                    { text: 'Nombre Solicitud', value: 'Nombre_solicitud' },
                      { text: 'Nombre Solicitante', value: 'Nombre_solicitante' },
                    { text: 'Dpi', value: 'dpi', sortable: false  },
                    { text: 'Fecha Entrega', value: 'fecha_entrega', sortable: false  },
                    { text: 'Fecha Solicitud', value: 'fecha_solicitud', sortable: false  },
                    { text: 'Cantidad', value: 'cantidad', sortable: false  },
                    { text: 'Descripcion', value: 'descripcion', sortable: false  }
                                    
                ],
                search: '',
                editedIndex: -1,
                codigo: '',
                fecha_registro:'',
                Nombre_solicitud: '',
                Nombre_solicitante: '',
                dpi:'',
                fecha_entrega:'',
                fecha_solicitud:'',
                cantidad:'',
                descripcion:'',
                valida: 0,
                validaMensaje:[],
                adModal: 0,
                adAccion: 0,
                adNombre: '',
                adId: ''             
            }
        },
        computed: {
            formTitle () {
                return this.editedIndex === -1 ? 'Nueva Solicitud' : 'Actualizar Solicitud'
            }
        },

        watch: {
            dialog (val) {
            val || this.close()
            }
        },

        created () {
            this.listar();
            this.select();
        },
        methods:{
            listar(){
                let me=this;
                axios.get('url').then(function(response){
                    //console.log(response);
                    me.usuarios=response.data;
                }).catch(function(error){
                    console.log(error);
                });
            },
            select(){
                let me=this;
                var rolesArray=[];
                axios.get('api/Roles/Select').then(function(response){
                    rolesArray=response.data;
                    rolesArray.map(function(x){
                        me.roles.push({text: x.nombre,value:x.idrol});
                    });
                }).catch(function(error){
                    console.log(error);
                });
            },
            editItem (item) {
                this.id=item.idusuario;
                this.idrol=item.idrol;
                this.nombre=item.nombre;
                this.tipo_documento=item.tipo_documento;
                this.num_documento=item.num_documento;
                this.direccion=item.direccion;
                this.telefono=item.telefono;
                this.email=item.email;
                this.password=item.password_hash;
                this.passwordAnt=item.password_hash;
                this.editedIndex=1;
                this.dialog = true
            },
            close () {
                this.dialog = false;
                this.limpiar();
            },
            limpiar(){
                this.id="";
                this.idrol="";
                this.nombre="";
                this.tipo_documento="";
                this.num_documento="";
                this.direccion="";
                this.telefono="";
                this.email="";
                this.password="";
                this.passwordAnt="";
                this.actPassword=false;
                this.editedIndex=-1;
            },
            guardar () {
                if (this.validar()){
                    return;
                }
                if (this.editedIndex > -1) {
                    //Código para editar
                    //Código para guardar
                    let me=this;
                    if (me.password!=me.passwordAnt){
                        me.actPassword=true;
                    }
                    axios.put('api/Usuarios/Actualizar',{
                        'idusuario':me.id,
                        'idrol':me.idrol,
                        'nombre':me.nombre,
                        'tipo_documento': me.tipo_documento,
                        'num_documento':me.num_documento,
                        'direccion':me.direccion,
                        'telefono': me.telefono,
                        'email':me.email,
                        'password':me.password,
                        'act_password':me.actPassword                        
                    }).then(function(response){
                        me.close();
                        me.listar();
                        me.limpiar();                        
                    }).catch(function(error){
                        console.log(error);
                    });
                } else {
                    //Código para guardar
                    let me=this;
                    axios.post('api/Usuarios/Crear',{
                        'idrol':me.idrol,
                        'nombre':me.nombre,
                        'tipo_documento': me.tipo_documento,
                        'num_documento':me.num_documento,
                        'direccion':me.direccion,
                        'telefono': me.telefono,
                        'email':me.email,
                        'password':me.password
                    }).then(function(response){
                        me.close();
                        me.listar();
                        me.limpiar();                        
                    }).catch(function(error){
                        console.log(error);
                    });
                }
            },
            validar(){
                this.valida=0;
                this.validaMensaje=[];

                if (this.nombre.length<3 || this.nombre.length>100){
                    this.validaMensaje.push("El nombre debe tener más de 3 caracteres y menos de 100 caracteres.");
                }
                if (!this.idrol){
                    this.validaMensaje.push("Seleccione un rol.");
                }
                if (!this.tipo_documento){
                    this.validaMensaje.push("Seleccione un tipo documento.");
                }

                if (!this.email){
                    this.validaMensaje.push("Ingrese el email del usuario.");
                }
                if (!this.password){
                    this.validaMensaje.push("Ingrese el password del usuario.");
                }
                if (this.validaMensaje.length){
                    this.valida=1;
                }
                return this.valida;
            },
            activarDesactivarMostrar(accion,item){
                this.adModal=1;
                this.adNombre=item.nombre;
                this.adId=item.idusuario;                
                if (accion==1){
                    this.adAccion=1;
                }
                else if (accion==2){
                    this.adAccion=2;
                }
                else{
                    this.adModal=0;
                }
            },
            activarDesactivarCerrar(){
                this.adModal=0;
            },
            activar(){
                let me=this;
                axios.put('api/Usuarios/Activar/'+this.adId,{}).then(function(response){
                    me.adModal=0;
                    me.adAccion=0;
                    me.adNombre="";
                    me.adId="";
                    me.listar();                       
                }).catch(function(error){
                    console.log(error);
                });
            },
            desactivar(){
                let me=this;
                axios.put('api/Usuarios/Desactivar/'+this.adId,{}).then(function(response){
                    me.adModal=0;
                    me.adAccion=0;
                    me.adNombre="";
                    me.adId="";
                    me.listar();                       
                }).catch(function(error){
                    console.log(error);
                });
            }
        }        
    }
</script>