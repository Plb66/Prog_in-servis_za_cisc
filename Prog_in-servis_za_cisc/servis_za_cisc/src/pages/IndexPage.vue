<template>
  <q-page padding class="flex flex-center">
    <div class="full-with">

      <q-card>
      <q-card-section>
        <div class="q-gutter-md full-with" style="max-width: 500px">
        <div class="full-with">
          <h5 class="q-my-sm text-center">Login</h5>
        </div>
      <q-input  filled v-model="inputUsername" label="Username" placeholder="Korisnikov username">
      </q-input>

      <q-input  filled v-model="inputPassword" label="Zaporuka" placeholder="Korisnikova Zaporuka">
      </q-input>



    </div>
      </q-card-section>
      <div class="row justify-center q-pa-sm">
        <q-btn align: between unelevated color="primary" label="Login" @click="$router.replace('admin')" class="full-with" text-align="center" />
      </div>
    </q-card>
    </div>


  </q-page>
</template>

<script setup>
import { ref } from 'vue'
import ErrorNotFound from './ErrorNotFound.vue';

const inputUsername = ref('')
const inputPassword = ref('')
</script>
