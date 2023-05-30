<template>
  <q-page padding class="flex flex-center">
    <div class="q-gutter-md full-with" style="max-width: 500px">
      <h1>Trenutni korisnik: {{ this.username }}</h1>
      <q-card>
        <q-card-section>
          <div class="row justify-center q-pa-md">
            <q-btn align: between unelevated color="primary"
            @click="$router.replace('korisnik/novi_zahtjev')" label="Pošalji zahtjev" text-align="center" />
          </div>
          <div class="row justify-center q-pa-md">
            <q-btn align: between unelevated color="primary"
            @click="$router.replace('korisnik/popis_zahtjeva_kor')" label="Popis
            zahtjeva" text-align="center" />
          </div>
          <div class="row justify-center q-pa-md">
            <q-btn align: between unelevated color="primary"
            @click="$router.push('/')" label="Odjava" text-align="center" />
          </div>
        </q-card-section>
      </q-card>
    </div>
  </q-page>
</template>
<script>
import { current_user } from "pages/IndexPage.vue";
export default {
  data() {
    return {
      username: "h",
      number: 0
    }
  },
  mounted() {
    if (current_user != undefined) {
      localStorage.setItem("current_user_number", current_user[0].id_klijenta);
      localStorage.setItem("current_user_name", current_user[0].kor_ime);
    }
    this.username=localStorage.getItem("current_user_name");
    this.number=localStorage.getItem("current_user_number");
  },
};
</script>
<script setup>
</script>



