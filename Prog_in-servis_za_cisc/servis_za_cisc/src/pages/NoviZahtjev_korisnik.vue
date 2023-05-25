<template>
  <div class="bg-image">
    <q-page padding class="flex flex-center">
      <q-card>
        <q-card-section>
          <div class="q-gutter-md full-with" style="max-width: 500px">
            <div class="full-with">
              <div class="q-gutter-md" style="max-width: 350px">
                <input
                  type="text"
                  id="datum"
                  name="datum"
                  placeholder="Datum oblika 2000-01-01"
                /><br />
                <input
                  type="text"
                  id="vrijeme"
                  name="vrijeme"
                  placeholder="Unesi vrijeme oblika 12:00"
                /><br />
                <input
                  type="text"
                  id="adresa"
                  name="adresa"
                  placeholder="Unesi adresu smještaja"
                /><br />
                <input
                  type="text"
                  id="tel_broj"
                  name="tel_broj"
                  placeholder="Unesi telefonski broj smještaja"
                /><br />
                <select name="vrsta_sm" id="vrsta_sm">
                  <option value="Apartman">Apartman</option>
                  <option value="Studio apartman">Studio apartman</option>
                  <option value="Kuća za iznajmljivanje">Kuća za iznajmljivanje</option>
                </select>
                <select name="vrsta_ci" id="vrsta_ci">
                  <option value="Generalka">Generalka</option>
                  <option value="Standardno">Standardno</option>
                  <option value="Promjena posteljine">Promjena posteljine</option>
                </select>
                <div class="row justify-center q-pa-md">
                  <div class="row justify-center q-pa-md">
                    <q-btn
                      label="Unesi"
                      v-on:click="sendRequest"
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
<script setup>
const model = ref("");
const model1 = ref("");
const inputDatum = ref("");
const inputAdresa = ref("");
const inputVrijeme = ref("");
</script>
<script>
// eslint-disable-next-line no-unused-vars
import { ref } from "vue";
import axios from "axios";
import current_user_number from "pages/IndexPage.vue";
const smjestaj = ["Apartman", "Studio apartman", "Kuća za iznajmljivanje"];
const ciscenje = ["generalka", "standardno", "promjena posteljine"];

export default {
  setup() {
    const options = ref(stringOptions);

    return {
      model: ref(null),
      model1: ref(null),
      stringOptions,
      options,

      filterFn(val, update) {
        if (val === "") {
          update(() => {
            options.value = stringOptions;
          });
          return;
        }

        update(() => {
          const needle = val.toLowerCase();
          options.value = stringOptions.filter(
            (v) => v.toLowerCase().indexOf(needle) > -1
          );
        });
      },
    };
  },
  methods: {
    sendRequest() {
      this.id_klijenta = 1;
      this.termin_z =
        document.getElementById("datum").value +" "+
        document.getElementById("vrijeme").value;
      this.adresa_z = document.getElementById("adresa").value;
      this.tip_ciscenje_z = document.getElementById("vrsta_ci").value;
      this.tip_apartman_z = document.getElementById("vrsta_sm").value;
      this.tel_broj_z = document.getElementById("tel_broj").value;
      axios.post("http://localhost:44335/api/sendRequest", {
        id_klijenta: this.id_klijenta,
        termin_z: this.termin_z,
        adresa_z: this.adresa_z,
        tip_ciscenje_z: this.tip_ciscenje_z,
        tip_apartman_z: this.tip_apartman_z,
        tel_broj_z: this.tel_broj_z,
        });
    },
  },
};
</script >

