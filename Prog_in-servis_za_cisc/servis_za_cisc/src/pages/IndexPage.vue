<template>
  <q-page padding class="flex flex-center">
    <div class="q-gutter-md" style="max-width: 350px">
      <q-input v-model="inputUsername" label="Username" placeholder="Korisnikov username">
      </q-input>

      <q-input v-model="inputPassword" label="Zaporuka" placeholder="Korisnikova Zaporuka">
      </q-input>


      <div class="row justify-center q-pa-md">
        <q-btn align="between" unelevated color="primary" @click="SubmitUnos" label="Potvrdi" text-align="center" />
      </div>
    </div>
  </q-page>
</template>

<script>
import { ref } from 'vue'

const inputUsername = ref('')
const inputPassword = ref('')
</script>
