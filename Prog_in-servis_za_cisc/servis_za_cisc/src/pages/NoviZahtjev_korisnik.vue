<template>
  <div class="bg-image">
  <q-page padding class="flex flex-center">
    <q-card>
      <q-card-section>
        <div class="q-gutter-md full-with" style="max-width: 500px">
        <div class="full-with">
    <div class="q-gutter-md" style="max-width: 350px">
      <q-input v-model="inputDatum" label="Datum čišćenja" placeholder="Primjer: 01/01/2001">
      </q-input>

      <q-input v-model="inputVrijeme" label="Vrijeme čišćenja" placeholder="Primjer: 12:00">
      </q-input>

      <q-input v-model="inputAdresa" label="Adresa smještaja" placeholder="Primjer: Ulica Bana Jelačića 12">
      </q-input>

      <q-select
        filled
        v-model="model"
        label="vrsta smještaja"
        :options="smjestaj"
        style="width: 250px"
        behavior="menu"
      />
      <q-select
        filled
        v-model="model1"
        label="vrsta čišćenja"
        :options="ciscenje"
        style="width: 250px"
        behavior="menu"
      />
      <div class="row justify-center q-pa-md">
        <div class="row justify-center q-pa-md">
          <q-btn
          label="Unesi"

          color="blue"
          class="q-ml-sm"
        />
        </div>
      </div>
    </div>
  </div>
</div>
</q-card-section>
  </q-card>
</q-page>
</div>
</template>

<script>
// eslint-disable-next-line no-unused-vars
import { ref } from 'vue'

const smjestaj = [
  'Apartman', 'Studio apartman', 'Kuća za iznajmljivanje'
]
const ciscenje = [
  'generalka', 'standardno', 'promjena posteljine'
]

export default {
  setup () {
    const options = ref(stringOptions)

    return {
      model: ref(null),
      model1: ref(null),
      stringOptions,
      options,

      filterFn (val, update) {
        if (val === '') {
          update(() => {
            options.value = stringOptions
          })
          return
        }

        update(() => {
          const needle = val.toLowerCase()
          options.value = stringOptions.filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
      }
    }
  }
}


</script >

<script setup>
const model = ref('')
const model1 = ref('')
const inputDatum = ref('')
const inputAdresa = ref('')
const inputVrijeme = ref('')
</script>

