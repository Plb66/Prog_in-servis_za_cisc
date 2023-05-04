<template>
  <q-page padding class="flex flex-center">
    <div class="q-gutter-md full-with" style="max-width: 500px">
    <q-card>
      <q-card-section>
              <div class="row justify-center q-pa-md">
                <q-btn align: between unelevated color="primary" @click="$router.replace('korisnik/novi_zahtjev')"
                  label="Zahtjevi na cekanju" text-align="center" />
              </div>
              <div class="row justify-center q-pa-md">
                <q-btn align: between unelevated color="primary" @click="$router.replace('korisnik/popis_zahtjeva_kor')"
                  label="Popis zahtjeva" text-align="center" />
              </div>

      </q-card-section>
    </q-card>
  </div>
  </q-page>
</template>

<script setup>
</script>


