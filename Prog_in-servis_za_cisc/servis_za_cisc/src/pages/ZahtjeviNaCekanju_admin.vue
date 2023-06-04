<template>
  <q-page padding class="flex flex-center">
    <div class="q-pa-md">
      <!--<q-card>
        <q-table
          flat
          bordered
          ref="tableRef"
          title="Zahtjevi na cekanju"
          :rows="this.zahtjevi"
          :columns="columns"
          row-key="name"
          selection="single"
          v-model:selected="selected"
          @selection="handleSelection"
        >
          <template v-slot:header-selection="scope">
            <q-checkbox v-model="scope.selected" />
          </template>

          <template v-slot:body-selection="scope">
            <q-checkbox
              :model-value="scope.selected"
              @update:model-value="
                (val, evt) => {
                  Object.getOwnPropertyDescriptor(scope, 'selected').set(
                    val,
                    evt
                  );
                }
              "
            />
          </template>
        </q-table>
        <div class="q-gutter-sm">
          <div class="q-pa-sm">
            <q-btn align: between unelevated color="green" label="Potvrdi"
            text-align="left" class="full-width" />
          </div>
          <div class="q-pa-sm">
            <q-btn align: between unelevated color="red" label="Odbi"
            text-align="right" class="full-width" />
          </div>
        </div>
      </q-card>-->
      <table style="width: 100%; background-color: white;" id="t1">
        <tr>
          <th>Termin</th>
          <th>Adresa</th>
          <th>Tip čišćenja</th>
          <th>Tip Apartmana</th>
          <th>Opravdan?</th>
        </tr>
        <tr v-for="i in zahtjevi" :key="i.id_zahtjeva">
          <td>{{ i.termin_z }}</td>
          <td>{{ i.adresa_z }}</td>
          <td>{{ i.tip_ciscenje_z }}</td>
          <td>{{ i.tip_apartman_z }}</td>
          <td>{{ i.opravdan }}</td>
          <button v-on:click="changeRequest(i.id_zahtjeva, i.opravdan)">Opravdaj zahtjev</button>
        </tr>
      </table>
      <q-btn align: between unelevated color="primary"
      @click="$router.push('/admin')" label="Natrag" text-align="center" />
    </div>
  </q-page>
</template>




<script>
import { ref, toRaw, nextTick } from "vue";
import axios from "axios";
const columns = [
  { name: "Termin", label: "Termin", field: "termin_z", sortable: true },
  { name: "Adresa", label: "Adresa", field: "adresa_z", sortable: true },
  { name: "Tip smjestaja", label: "Tip smjestaja", field: "tip_apartman_z" },
  { name: "Tip ciscenja", label: "Tip ciscenja", field: "tip_ciscenje_z" },
  { name: "Telefonski broj", label: "Telefonski broj", field: "tel_broj_z" },
  { name: "Opravdan", label: "Opravdan", field: "opravdan" },
];

let rows = [
  {
    name: "ivan ivic",
    Datum: "21/04/23",
    Vrijeme: "12:00",
    Adresa: "Bana jelacica 12",
    Tip_smjestaja: "apartman",
    Tip_ciscenja: "generalka",
  },
];

export default {
  data() {
    return {
      zahtjevi: [],
    };
  },
  mounted() {
    axios
      .get("http://localhost:44335/api/getAllRequests")
      .then((response) => {
        this.zahtjevi = response.data;
      })
      .catch((e) => {
        console.log(e);
      });
  },
  setup() {
    const tableRef = ref();
    const selected = ref([]);
    let storedSelectedRow;

    return {
      tableRef,
      selected,
      columns,
      rows,

      handleSelection({ rows, added, evt }) {
        // ignore selection change from header of not from a direct click event
        if (rows.length !== 1 || evt === void 0) {
          return;
        }

        const oldSelectedRow = storedSelectedRow;
        const [newSelectedRow] = rows;
        const { ctrlKey, shiftKey } = evt;

        if (shiftKey !== true) {
          storedSelectedRow = newSelectedRow;
        }

        // wait for the default selection to be performed
        nextTick(() => {
          if (shiftKey === true) {
            const tableRows = tableRef.value.filteredSortedRows;
            let firstIndex = tableRows.indexOf(oldSelectedRow);
            let lastIndex = tableRows.indexOf(newSelectedRow);

            if (firstIndex < 0) {
              firstIndex = 0;
            }

            if (firstIndex > lastIndex) {
              [firstIndex, lastIndex] = [lastIndex, firstIndex];
            }

            const rangeRows = tableRows.slice(firstIndex, lastIndex + 1);
            // we need the original row object so we can match them against the rows in range
            const selectedRows = selected.value.map(toRaw);

            selected.value =
              added === true
                ? selectedRows.concat(
                    rangeRows.filter(
                      (row) => selectedRows.includes(row) === false
                    )
                  )
                : selectedRows.filter(
                    (row) => rangeRows.includes(row) === false
                  );
          } else if (ctrlKey !== true && added === true) {
            selected.value = [newSelectedRow];
          }
        });
      },
    };
  },
  methods: {
    changeRequest(id_z, o){
      if(o==0){
        axios.put("http://localhost:44335/api/changeRequest", {
          id_zahtjeva: id_z
        });
        alert("Zahtjev uspješno opravdan")
      }else{
        alert("Zahtjev je već opravdan")
      }
    }
  }
};
</script>
