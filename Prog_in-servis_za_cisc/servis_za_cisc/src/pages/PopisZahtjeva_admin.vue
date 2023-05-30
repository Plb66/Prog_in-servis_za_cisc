<template>
  <q-page padding class="flex flex-center">
    <div class="q-pa-md full-with" style="max-width: 1500px">
      <div class="q-pa-md">
        <table style="width: 100%" id="t1">
          <tr>
            <th>Termin</th>
            <th>Adresa</th>
            <th>Tip čišćenja</th>
            <th>Tip Apartmana</th>
          </tr>
          <tr v-for="i in ciscenja" :key="i.id_ciscenja">
            <td>{{ i.termin_c }}</td>
            <td>{{ i.adresa_c }}</td>
            <td>{{ i.tip_ciscenje_c }}</td>
            <td>{{ i.tip_apartman_c }}</td>
          </tr>
        </table>
        <q-btn align: between unelevated color="primary"
        @click="$router.push('/admin')" label="Natrag" text-align="center" />
      </div>
    </div>
  </q-page>
</template>


<script>
import axios from 'axios';
const columns = [
  {
    name: "name",
    required: true,
    label: "Ime korisnika",
    align: "left",
    field: (row) => row.name,
    format: (val) => `${val}`,
    sortable: true,
  },
  {
    name: "Datum",
    align: "center",
    label: "Datum",
    field: "Datum",
    sortable: true,
  },
  { name: "Vrijeme", label: "Vrijeme", field: "Vrijeme" },
  { name: "Adresa", label: "Adresa", field: "Adresa", sortable: true },
  { name: "Tip smjestaja", label: "Tip smjestaja", field: "Tip_smjestaja" },
  { name: "Tip ciscenja", label: "Tip ciscenja", field: "Tip_ciscenja" },
  { name: "Opravdan", label: "Opravdan", field: "opravdan" },
];

const rows = [
  {
    name: "ivan ivic",
    Datum: "21/04/23",
    Vrijeme: "12:00",
    Adresa: "Bana jelacica 12",
    Tip_smjestaja: "apartman",
    Tip_ciscenja: "generalka",
    opravdan: "da",
  },
];

export default {
  setup() {
    return {
      columns,
      rows,
    };
  },
  data() {
    return {
      ciscenja: [],
    };
  },
  mounted() {
    axios
      .get("http://localhost:44335/api/getAllCleanups")
      .then((response) => {
        this.ciscenja = response.data;
      })
      .catch((e) => {
        console.log(e);
      });
  },
};
</script>
