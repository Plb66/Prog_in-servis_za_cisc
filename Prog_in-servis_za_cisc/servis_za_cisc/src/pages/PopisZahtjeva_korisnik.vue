<template>
  <q-page padding class="flex flex-center">
    <div class="q-pa-md full-with" style="max-width: 1500px">
      <div class="q-pa-md">
        <!--<q-table
          title="Zahtjevi"
          :rows="rows"
          :columns="columns"
          row-key="name"
        />-->
        <table style="width: 100%" id="t1">
          <tr>
            <th>Termin</th>
            <th>Adresa</th>
            <th>Tip čišćenja</th>
            <th>Tip Apartmana</th>
            <th>Opravdan?</th>
          </tr>
          <tr v-for="i in blist" :key="i.id_zahtjeva">
            <td>{{ i.termin_z }}</td>
            <td>{{ i.adresa_z }}</td>
            <td>{{ i.tip_ciscenje_z }}</td>
            <td>{{ i.tip_apartman_z }}</td>
            <td>{{ i.opravdan }}</td>
          </tr>
        </table>
        <q-btn align: between unelevated color="primary"
            @click="$router.push('/korisnik')" label="Natrag" text-align="center" />
      </div>
    </div>
  </q-page>
</template>


<script>
import axios from "axios";
const columns = [
  {
    name: "Termin",
    align: "center",
    label: "Termin",
    field: "termin",
    sortable: true,
  },
  { name: "Adresa", label: "Adresa", field: "Adresa", sortable: true },
  { name: "Tip smjestaja", label: "Tip smjestaja", field: "Tip_smjestaja" },
  { name: "Tip ciscenja", label: "Tip ciscenja", field: "Tip_ciscenja" },
  { name: "Opravdan", label: "Opravdan", field: "opravdan" },
];

const rows = [
  {
    termin: "2000/01/01 18:54",
    Adresa: "Bana jelacica 12",
    Tip_smjestaja: "apartman",
    Tip_ciscenja: "generalka",
    opravdan: "ne",
  },
];

export default {
  data() {
    return {
      blist: [],
      number: 0
    };
  },
  setup() {
    return {
      columns,
      rows,
    };
  },
  mounted() {
    this.number=localStorage.getItem("current_user_number");
    axios
      .get("http://localhost:44335/api/getRequest/" + this.number)
      .then((response) => {
        this.blist = response.data;
      })
      .catch((e) => {
        console.log(e);
      });
  },
};
</script>
