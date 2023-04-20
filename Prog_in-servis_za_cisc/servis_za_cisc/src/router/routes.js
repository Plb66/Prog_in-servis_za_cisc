
const routes = [
  {
    path: '/',
    component: () => import('layouts/NewLayout'),
    children: [
      {
        path: ''
      ,
       component: () => import('pages/IndexPage.vue')
      },
    ]


  },
{
  path: '/admin',
    component: () => import('layouts/NewLayout'),
    children: [
      {
        path: ''
      ,
       component: () => import('pages/izbornikAdmin.vue')
      },
      {
        path: 'kalendar'
      ,
       component: () => import('pages/kalendarAdmin.vue')
      },
      {
        path: 'popis_zahtjeva'
      ,
       component: () => import('pages/PopisZahtjeva_admin.vue')
      },
      {
        path: 'zahtjevi_na_cekanju'
      ,
       component: () => import('pages/ZahtjeviNaCekanju_admin.vue')
      },
    ],


},
{
  path: '/korisnik',
  component: () => import('layouts/NewLayout'),
  children: [
  {
    path: ''
  ,
   component: () => import('pages/izbornikKorisnik.vue')
  },

  {
    path: 'novi_zahtjev'
  ,
   component: () => import('pages/NoviZahtjev_korisnik.vue')
  },

  {
    path: 'popis_zahtjeva_kor'
  ,
   component: () => import('pages/PopisZahtjeva_korisnik.vue')
  },
]
},
  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
