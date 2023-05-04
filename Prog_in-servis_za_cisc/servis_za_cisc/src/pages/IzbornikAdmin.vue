<template>
  <q-page padding class="flex flex-center">
    <div class="q-gutter-md full-with" style="max-width: 500px">
    <q-card>
      <q-card-section>
              <div class="row justify-center q-pa-md">
                <q-btn align: between unelevated color="primary" @click="$router.replace('admin/kalendar')"
                  label="Kalendar" text-align="center" />
              </div>
              <div class="row justify-center q-pa-md">
                <q-btn align: between unelevated color="primary" @click="$router.replace('admin/zahtjevi_na_cekanju')"
                  label="Zahtjevi na čekanj" text-align="center" />
              </div>
              <div class="row justify-center q-pa-md">
                <q-btn align: between unelevated color="primary" @click="$router.replace('admin/popis_zahtjeva')"
                  label="Popopis zahtjeva" text-align="center" />
              </div>
      </q-card-section>
    </q-card>
  </div>
  </q-page>
</template>

<script setup>
</script>

