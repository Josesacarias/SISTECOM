import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Categoria from './components/Categoria.vue'
import Articulo from './components/Articulo.vue'
import Rol from './components/Rol.vue'
import Usuario from './components/Usuario.vue'
import Cliente from './components/Cliente.vue'
import Proveedor from './components/Proveedor.vue'
import ClienteEmpresarial from './components/ClienteEmpresarial.vue'
import ArticuloCompras from './components/ArticuloCompras.vue'
import SolicitudCompra from './components/SolicitudCompra.vue'
import OrdenCompra from './components/OrdenCompra.vue'
import Tickets from './components/Tickets.vue'
import Login from './components/Login.vue'
import Login1 from './views/Login1.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/categorias',
      name: 'categorias',
      component: Categoria
    },
    {
      path: '/articulos',
      name: 'articulos',
      component: Articulo
    },
    {
      path: '/roles',
      name: 'roles',
      component: Rol
    },
    {
      path: '/usuarios',
      name: 'usuarios',
      component: Usuario
    },
    {
      path: '/clientes',
      name: 'clientes',
      component: Cliente
    },
    {
      path: '/proveedores',
      name: 'proveedores',
      component: Proveedor
    },

    {
      path: '/ClienteEmpresarial',
      name: 'ClienteEmpresarial',
      component: ClienteEmpresarial
    },

    {
      path: '/ArticuloCompras',
      name: 'ArticuloCompras',
      component: ArticuloCompras
    },


    {
      path: '/SolicitudCompra',
      name: 'SolicitudCompra',
      component: SolicitudCompra
    },

    {
      path: '/OrdenCompra',
      name: 'OrdenCompra',
      component: OrdenCompra
    },


    {
      path: '/Tickets',
      name: 'Tickets',
      component: Tickets
    },

    {
      path: '/Login ',
      name: 'Login',
      component: Login
    },

    {
      path: '/Login1 ',
      name: 'Login1',
      component: Login1
    }

 

  ]
})
