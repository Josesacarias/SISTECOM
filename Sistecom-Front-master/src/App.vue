<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
     
    >
      <v-list dense>
        <template>
          <v-list-tile :to="{name:'Home'}">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Inicio
            </v-list-tile-title>
          </v-list-tile>
        </template>

        <template>
          <v-list-tile :to="{name:'Login'}">
            <v-list-tile-action>
              <v-icon>login</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Login
            </v-list-tile-title>
          </v-list-tile>
        </template>


        <template>
          <v-list-group color="teal">
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                <v-icon>inventory_2</v-icon>
                  Almacén
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'categorias'}">
              <v-list-tile-action>
                <v-icon>category</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Categorías
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'articulos'}">
              <v-list-tile-action>
                <v-icon>article</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  
                  Artículos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

         


          </v-list-group>
        </template>
        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  <v-icon>shopping_bag</v-icon>
                  Compras
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


              <v-list-tile :to="{ name: 'ArticuloCompras'}">
              <v-list-tile-action>
                <v-icon>description</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                Articulos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'SolicitudCompra'}">
              <v-list-tile-action>
                <v-icon>description</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                 Solicitud de Compras
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'OrdenCompra'}">
              <v-list-tile-action>
                <v-icon>description</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                 Orden de compra
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'proveedores'}">
              <v-list-tile-action>
                <v-icon>inventory</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Proveedores
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            </v-list-group>
        </template>
       
       
        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  <v-icon>shopping_bag</v-icon>
                  Tickets
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'Tickets'}">
              <v-list-tile-action>
                <v-icon>description</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Tickets
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
           

          </v-list-group>
        </template>
        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  <v-icon>receipt</v-icon>
                  Ventas
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: ''}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Ventas
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'clientes'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Clientes Residencial
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'ClienteEmpresarial'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Clientes Empresarial
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

           
            <v-list-tile :to="{ name: 'clientes'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Clientes Potenciales
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


          </v-list-group>
        </template>
        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                  
                <v-list-tile-title >
                  <v-icon>account_box</v-icon>
                 Recursos Humanos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'roles'}">
              <v-list-tile-action>
                <v-icon>local_police</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Roles
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: 'usuarios'}">
              <v-list-tile-action>
                <v-icon>badge</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Usuarios
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

          </v-list-group>
        </template>
        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  <v-icon>query_stats</v-icon>
                  Consultas
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: ''}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Consultas compras
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>
            <v-list-tile :to="{ name: ''}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Reportes
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

          </v-list-group>

         

          

             

        </template>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="blue darken-3"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">SISTECOM</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      
      
      <v-btn :to="{name: 'Login'}" color="primary">
        <v-icon>apps</v-icon> Login
      
      </v-btn>
    
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark >
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="primary" class="white--text">
            <v-card-text class="white--text pt-0">
              Sistecom &copy;2022
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>

<script>

export default {
  name: 'App',
  data () {
    return {
      clipped: false,
      drawer: true,
      fixed: false,
      items: [{
        icon: 'bubble_chart',
        title: 'Inspire'
      }],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Vuetify.js'
    }
  }
}
</script>
