<template>

    <v-layout align-center justify-center>
        
        <v-flex xs12 sm8 md6 lg5 xl4>
                    
            <v-card>
                
                <v-toolbar dark color="blue darken-3">
                    
                    <v-toolbar-title>
                         
                        INGRESO AL SISTEMA
                    </v-toolbar-title>
                   
                
                </v-toolbar>
                
                
                <v-card-text>
                    <v-text-field prepend-icon="person"  autofocus color="accent" label="Email" required append-icon="far fa-envelope">
                    </v-text-field>
                    <v-text-field prepend-icon="lock"  type="password" color="accent" label="Password" required>
                    </v-text-field>
                    <v-flex class="red--text" v-if="error">
                        {{error}}
                    </v-flex>
                </v-card-text>
                <v-card-actions class="px-3 pb-3">
                    <v-flex text-xs-right>
                     <v-btn :to="{name:'App'}" color="primary" >Ingresar</v-btn>
                        
                    </v-flex>
                </v-card-actions>
            </v-card>
        </v-flex>
    </v-layout>
</template>
<script>
import axios from 'axios'
export default {
    data(){
        return {
            
        }
    },
  _methods: {
    
 
    },
    
}
</script>

