<template>
  <q-page padding class="flex flex-center">
    <div class="full-with">
      <q-card>
        <q-card-section>
          <div class="q-gutter-md full-with" style="max-width: 500px">
            <div class="full-with">
              <h5 class="q-my-sm text-center">Login</h5>
            </div>
            <input
              type="text"
              id="kor_ime"
              name="kor_ime"
              placeholder="Korisničko ime"
            /><br />
            <input
              type="text"
              id="lozinka"
              name="lozinka"
              placeholder="Lozinka"
            /><br />
          </div>
        </q-card-section>
        <div class="row justify-center q-pa-sm">
          <q-btn align: between unelevated color="primary" label="Login"
          v-on:click="log_in" class="full-with" text-align="center" />
        </div>
      </q-card>
    </div>
  </q-page>
</template>
<script>
import axios from "axios";
var userData, current_user;
export default {
  mounted() {
  },
  methods: {
    log_in() {
      this.kor_ime = document.getElementById("kor_ime").value;
      this.lozinka = document.getElementById("lozinka").value;
      /*for (let i = 0; i < userData.length; i++) {
        if(userData[i].kor_ime==this.kor_ime&&userData[i].lozinka==this.lozinka){
          current_user=userData[i];
          this.$router.replace("korisnik");
        }
      }*/
      axios
        .get("http://localhost:44335/api/log_in/" + this.kor_ime +'/'+ this.lozinka)
        .then((response) => {
          if(response.data.length!=0){
            current_user=response.data;
            if (current_user[0].kor_ime=="Admin") {
              this.$router.replace("admin");
            } else {
              this.$router.replace("korisnik");
            }
          }else{
            alert("Krivi login!")
          }
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
};
export { current_user };
</script>
<script setup>
import { ref } from "vue";
import ErrorNotFound from "./ErrorNotFound.vue";
const inputUsername = ref("");
const inputPassword = ref("");
</script>
