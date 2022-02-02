<template>
    <v-layout align-start>
        <v-flex>
            <v-toolbar flat color="white">
                <v-toolbar-title>Artículos</v-toolbar-title>
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
                                <v-flex xs6 sm6 md6>
                                    <v-text-field v-model="codigo" label="Código">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field type="date" label="Fecha de Registro">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm12 md12>
                                    <v-text-field v-model="nombre" label="Nombre"></v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field v-model="codigo" label="Código sku">
                                    </v-text-field>
                                </v-flex>
                                 <v-flex xs6 sm6 md6>
                                    <v-text-field v-model="codigo" label="Código barras">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-select v-model="idcategoria"
                                    :items="categorias" label="Categoría">
                                    </v-select>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-select v-model="idcategoria"
                                    :items="categorias" label="codigo proveedor ">
                                    </v-select>
                                </v-flex>
                                 <v-flex xs6 sm6 md6>
                                    <v-select v-model="idcategoria"
                                    :items="categorias" label="Nombre proveedor ">
                                    </v-select>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field  v-model="codigo" label="Factura proveedor">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field type="number" v-model="codigo" label="Precio de compra">
                                    </v-text-field>
                                </v-flex>
                               
                                <v-flex xs6 sm6 md6>
                                    <v-select v-model="idcategoria"
                                    :items="categorias" label="unidad de medida">
                                    </v-select>
                                </v-flex>
                                
                                <v-flex xs6 sm6 md6>
                                    <v-text-field type="number" v-model="stock" label="IVA">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field type="number"  label="Precio Venta">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field v-model="codigo" label="Maximo de producto">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs6 sm6 md6>
                                    <v-text-field v-model="codigo" label="Minimo de producto">
                                    </v-text-field>
                                </v-flex>
                                <v-flex xs12 sm12 md12>
                                    <v-text-field v-model="descripcion" label="Descripción"></v-text-field>
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
                :items="articulos"
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
                    <td>{{ props.item.nombre }}</td>
                    <td>{{ props.item.codigo_sku }}</td>
                    <td>{{ props.item.codigo_barras }}</td>
                    <td>{{ props.item.categoria }}</td>
                    <td>{{ props.item.codigo_proveedor}}</td>
                    <td>{{ props.item.nombre_proveedor }}</td>
                    <td>{{ props.item.factura_proveedor }}</td>
                    <td>{{ props.item.precio_compra }}</td>
                    <td>{{ props.item.unidad_medida }}</td>
                    <td>{{ props.item.iva }}</td>
                    <td>{{ props.item.precio_venta }}</td>
                    <td>{{ props.item.maximo_producto }}</td>
                    <td>{{ props.item.minimo_producto }}</td>
                    <td>{{ props.item.stock }}</td>
                    <td>{{ props.item.precio_venta }}</td>
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
                articulos:[],                
                dialog: false,
                headers: [
                    { text: 'Opciones', value: 'opciones', sortable: false },
                    { text: 'Código', value: 'codigo', sortable: false },
                    { text: 'Fecha Registro', value: 'fecha_registro', sortable: false },
                    { text: 'Nombre', value: 'nombre' },
                    { text: 'Codigo SKU', value: 'sku' },
                    { text: 'Codigo de barras', value: 'codigo_barras' },
                    { text: 'Categoria', value: 'categoria' },
                    { text: 'Codigo Proveedor', value: 'codigo_proveedor' },
                    { text: 'Nombre Proveedor', value: 'nombre_proveedor' },
                    { text: 'Factura Proveedor', value: 'factura_proveedor' },
                    { text: 'Precio Compra', value: 'precio_compra' },
                    { text: 'Unidad de Medida', value: 'unidad_medida' },
                    { text: 'IVA', value: 'iva' },
                    { text: 'Precio Venta', value: 'precio_venta' },
                    { text: 'Maximo Producto', value: 'maximo_producto' },
                    { text: 'Minimo Producto', value: 'minimo_producto' },
                    { text: 'Descripción', value: 'descripcion', sortable: false  }
                             
                ],
                search: '',
                editedIndex: -1,
                id: '',
                idcategoria:'',
                categorias:[                   
                ],
                codigo: '',
                fecha_registro:'',
                nombre: '',
                sku:'',
                codigo_barras:'',
                categoria:'',
                codigo_proveedor:'',
                nombre_proveedor:'',
                factura_proveedor:'',
                precio_compra:'',
                unidad_medida:'',
                iva:'',
                precio_venta:'',
                maximo_producto:'',
                minimo_producto:'',
                stock: 0,
                precio_venta: 0,
                descripcion: '',
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
                return this.editedIndex === -1 ? 'Nuevo artículo' : 'Actualizar artículo'
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
                    me.articulos=response.data;
                }).catch(function(error){
                    console.log(error);
                });
            },
            select(){
                let me=this;
                var categoriasArray=[];
                axios.get('url').then(function(response){
                    categoriasArray=response.data;
                    categoriasArray.map(function(x){
                        me.categorias.push({text: x.nombre,value:x.idcategoria});
                    });
                }).catch(function(error){
                    console.log(error);
                });
            },
            editItem (item) {
                this.id=item.idarticulo;
                this.id=item.fecha_registro;
                this.idcategoria=item.idcategoria;
                this.codigo=item.codigo_sku;
                this.codigo=item.codigo_barras;
                this.codigo=item.categoria;
                this.codigo=item.codigo_proveedor;
                this.codigo=item.nombre_proveedor;
                this.codigo=item.factura_proveedor;
                this.codigo=item.precio_compra;
                this.codigo=item.unidad_medida;
                this.codigo=item.iva;
                this.codigo=item.maximo_producto;
                this.codigo=item.minimo_producto;
                this.nombre=item.nombre;
                this.stock=item.stock;
                this.precio_venta=item.precio_venta;
                this.descripcion=item.descripcion;
                this.editedIndex=1;
                this.dialog = true
            },
            close () {
                this.dialog = false;
                this.limpiar();
            },
            limpiar(){
                this.id="";
                this.fecha_registro="";
                this.idcategoria="";
                this.codigo_sku="";
                this.codigo_barras="";
                this.categoria="";
                this.codigo_proveedor="";
                this.nombre_proveedor="";
                this.factura_proveedor="";
                this.precio_compra="";
                this.unidad_medida="";
                this.iva="";
                this.maximo_producto="";
                this.minimo_producto="";
                this.nombre="";
                this.stock="";
                this.precio_venta="";
                this.descripcion="";
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
                    axios.put('url',{
                        'idarticulo':me.id,
                        'fecha_registro':me.fecha_registro,
                        'nombre': me.nombre,
                        'idcategoria':me.idcategoria,
                        'codigo_sku':me.codigo_sku,
                        'codigo_barras':me.codigo_barras,
                        'codigo_proveedor':me.codigo_proveedor,
                        'nombre_proveedor':me.nombre_proveedor,
                        'factura_proveedor':me.factura_proveedor,
                        'precio_compra':me.precio_compra,
                        'unidad_medida':me.unidad_medida,
                        'iva':me.iva,
                        'precio_venta': me.precio_venta,
                        'maximo_producto': me.maximo_producto,
                        'minimo_producto': me.minimo_producto,
                        'stock':me.stock,
                        'precio_venta':me.precio_venta,
                        'descripcion': me.descripcion
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
                    axios.post('url',{
                        'idarticulo':me.id,
                        'fecha_registro':me.fecha_registro,
                        'nombre': me.nombre,
                        'idcategoria':me.idcategoria,
                        'codigo_sku':me.codigo_sku,
                        'codigo_barras':me.codigo_barras,
                        'codigo_proveedor':me.codigo_proveedor,
                        'nombre_proveedor':me.nombre_proveedor,
                        'factura_proveedor':me.factura_proveedor,
                        'precio_compra':me.precio_compra,
                        'unidad_medida':me.unidad_medida,
                        'iva':me.iva,
                        'precio_venta': me.precio_venta,
                        'maximo_producto': me.maximo_producto,
                        'minimo_producto': me.minimo_producto,
                        'stock':me.stock,
                        'precio_venta':me.precio_venta,
                        'descripcion': me.descripcion
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

                if (this.nombre.length<3 || this.nombre.length>50){
                    this.validaMensaje.push("El nombre debe tener más de 3 caracteres y menos de 50 caracteres.");
                }
                if (!this.idcategoria){
                    this.validaMensaje.push("Seleccione una categoría.");
                }
                if (!this.stock || this.stock==0){
                    this.validaMensaje.push("Ingrese el stock inicial del artículo.");
                }
                if (!this.precio_venta || this.precio_venta==0){
                    this.validaMensaje.push("Ingrese el precio de venta del artículo.");
                }
                if (this.validaMensaje.length){
                    this.valida=1;
                }
                return this.valida;
            },
            activarDesactivarMostrar(accion,item){
                this.adModal=1;
                this.adNombre=item.nombre;
                this.adId=item.idarticulo;                
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
                axios.put('api/Articulos/Activar/'+this.adId,{}).then(function(response){
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
                axios.put('api/Articulos/Desactivar/'+this.adId,{}).then(function(response){
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
