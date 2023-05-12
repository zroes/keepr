import{_ as V,u as M,w as S,c as i,k as j,M as A,P as p,K as F,a as D,b as B,V as N,l as E,d as a,e,t as u,F as m,f as w,m as q,g as n,h as f,i as l,j as c,A as d,n as z,q as L,p as h}from"./index.b8608f64.js";const O={setup(){const o=M();async function v(){try{await h.getProfile(o.params.profileId)}catch(s){p.error(s)}}async function y(){try{await h.getKeeps(o.params.profileId)}catch(s){p.error(s)}}async function t(){try{await h.getVaults(o.params.profileId)}catch(s){p.error(s)}}return S(()=>{o.params.profileId,v(),y(),t()}),{profile:i(()=>d.profile),keeps:i(()=>d.keeps),vaults:i(()=>d.vaults),activeKeep:i(()=>d.activeKeep),route:o,accountId:i(()=>d.account.id),async setActive(s){try{await j.setActive(s),A.getOrCreateInstance("#keep-details").show()}catch(g){p.error(g)}}}},components:{KeepCard:F,MyModal:D,KeepDetails:B,VaultCard:N,ProfileForm:E}},_=o=>(z("data-v-b4877447"),o=o(),L(),o),R={key:0,class:"container-fluid my-3"},G={class:"row justify-content-center"},H={class:"col-md-7 text-center"},J={class:"position-relative mb-3"},Q=["src"],T={class:"position-absolute move"},U=["src"],W={key:0,class:"d-flex justify-content-end"},X=_(()=>e("h5",{class:"ff-ox user-select-none selectable rounded px-2","data-bs-toggle":"dropdown"},"\u2022\u2022\u2022",-1)),Y=_(()=>e("ul",{class:"dropdown-menu py-0"},[e("li",null,[e("span",{class:"dropdown-item selectable","data-bs-toggle":"modal","data-bs-target":"#edit-profile"},"edit")])],-1)),Z=[X,Y],$={key:1,class:"hidden"},ee=_(()=>e("p",null,"\u2022",-1)),te=[ee],oe={class:"row justify-content-center"},se={class:"col-md-5 text-center my-3"},ae={class:"d-flex justify-content-evenly"},ce={class:"row justify-content-center"},ne={class:"col-md-8"},le=_(()=>e("h2",null,"Vaults:",-1)),re={class:"row"},ie={class:"col-md-4 px-md-2"},de=_(()=>e("h2",null,"Keeps:",-1)),_e={class:"masonry-with-columns my-2"},pe=["onClick"];function ue(o,v,y,t,s,g){const b=l("VaultCard"),I=l("router-link"),K=l("KeepCard"),P=l("KeepDetails"),k=l("MyModal"),x=l("ProfileForm");return c(),a(m,null,[t.profile?(c(),a("div",R,[e("div",G,[e("div",H,[e("div",J,[e("img",{src:t.profile.coverImg,class:"img-fluid rounded",alt:""},null,8,Q),e("div",T,[e("img",{src:t.profile.picture,alt:"",class:"rounded prof"},null,8,U)])]),t.route.params.profileId==t.accountId?(c(),a("div",W,Z)):(c(),a("div",$,te))])]),e("div",oe,[e("div",se,[e("h1",null,u(t.profile.name),1),e("div",ae,[e("h5",null,u(t.vaults.length)+" vaults | "+u(t.keeps.length)+" keeps",1)])])]),e("div",ce,[e("div",ne,[le,e("div",re,[(c(!0),a(m,null,w(t.vaults,r=>(c(),a("div",ie,[n(I,{to:{name:"Vault",params:{vaultId:r.id}}},{default:f(()=>[n(b,{vault:r},null,8,["vault"])]),_:2},1032,["to"])]))),256))]),de,e("div",_e,[(c(!0),a(m,null,w(t.keeps,(r,C)=>(c(),a("div",{class:"mb-4",onClick:me=>t.setActive(r.id),key:C},[n(K,{keep:r,class:"selectable rounded"},null,8,["keep"])],8,pe))),128))])])])])):q("",!0),n(k,{id:"keep-details",size:"modal-lg"},{body:f(()=>[n(P,{keep:t.activeKeep},null,8,["keep"])]),_:1}),n(k,{id:"edit-profile"},{body:f(()=>[n(x)]),_:1})],64)}const he=V(O,[["render",ue],["__scopeId","data-v-b4877447"]]);export{he as default};
