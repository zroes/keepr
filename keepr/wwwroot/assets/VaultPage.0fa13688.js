import{_ as K,u as C,w as M,c as l,k as g,M as j,P as s,v,r as k,K as A,a as P,d as a,e as t,t as d,m as u,F as w,f as N,g as h,h as D,s as S,i as m,j as o,A as _}from"./index.80fcd7f5.js";const B={setup(){const c=C();async function n(){try{await v.getVault(c.params.vaultId)}catch(e){e.response.data=="No vault found at id "+c.params.vaultId?(s.error(e.response.data),k.push("/")):s.error(e)}}async function p(){try{await g.getKeepsInVault(c.params.vaultId)}catch(e){s.error(e)}}return M(()=>{c.params.vaultId,n(),p()}),{vault:l(()=>_.activeVault),keeps:l(()=>_.keeps),activeKeep:l(()=>_.activeKeep),accountId:l(()=>_.account.id),async setActive(e){try{await g.setActive(e),j.getOrCreateInstance("#keep-details").show()}catch(r){s.error(r)}},async deleteVault(){try{if(await s.confirm("Are you sure?","This action cannot be undone")){const e=this.vault.id;await v.deleteVault(e),k.push("/profile/"+this.vault.creatorId)}}catch{}},async toggleVis(e,r){try{await s.confirm(`Make this vault ${e?"public":"private"}?`,"Are you sure?")&&await v.toggleVis(e,r)}catch(f){s.error(f)}}}},components:{KeepCard:A,MyModal:P}},z={key:0,class:"container-fluid"},E={class:"row justify-content-center mt-3"},F={class:"col-md-4 justify-content-center"},T={class:"position-relative"},L=["src","alt"],O={class:"position-absolute gradient rounded bottom-0 text-light text-center ff-marko text-shadow"},R={class:""},U={class:""},q=S("by "),G=["href"],H={class:"justify-content-end d-flex"},J={key:0},Q=t("i",{class:"text-danger mdi mdi-lock"},null,-1),W=[Q],X={class:"row justify-content-center my-4"},Y={class:"col-md-2 text-center"},Z={class:"bg-secondary d-inline p-2 rounded-ish ff-ox"},$={class:"row"},ee={class:"col-md-8 text-center"},te={key:0,class:"d-flex justify-content-end"},se=t("h5",{class:"ff-ox user-select-none selectable rounded px-2","data-bs-toggle":"dropdown"},"\u2022\u2022\u2022",-1),ae={class:"dropdown-menu py-0"},oe={class:"masonry-with-columns my-2 mb-5"},ne=["onClick"],ce={key:0,class:"row justify-content-center my-3"},re={class:"col-2 text-center"};function ie(c,n,p,e,r,f){var y;const x=m("KeepCard"),b=m("KeepDetails"),V=m("MyModal");return o(),a(w,null,[e.vault?(o(),a("div",z,[t("div",E,[t("div",F,[t("div",T,[t("img",{class:"img-fluid rounded size-it",src:e.vault.imgUrl,alt:e.vault.name},null,8,L),t("div",O,[t("h1",R,d(e.vault.name),1),t("h5",U,[q,t("a",{href:`/#/profile/${e.vault.creatorId}`},d(e.vault.creator.name),9,G)]),t("div",H,[e.vault.isPrivate?(o(),a("h4",J,W)):u("",!0)])])])])]),t("div",X,[t("div",Y,[t("h6",Z,d((y=e.keeps)==null?void 0:y.length)+" Keeps",1)])]),t("div",$,[t("div",ee,[e.vault.creatorId==e.accountId?(o(),a("div",te,[se,t("ul",ae,[t("li",null,[t("span",{class:"dropdown-item selectable",onClick:n[0]||(n[0]=i=>e.toggleVis(e.vault.isPrivate,e.vault.id))},"make "+d(e.vault.isPrivate?"public":"private"),1)])])])):u("",!0)])]),t("div",oe,[(o(!0),a(w,null,N(e.keeps,(i,I)=>(o(),a("div",{class:"mb-4",onClick:le=>e.setActive(i.id),key:I},[h(x,{keep:i,class:"selectable rounded"},null,8,["keep"])],8,ne))),128))]),e.accountId==e.vault.creatorId?(o(),a("div",ce,[t("div",re,[t("button",{class:"btn btn-warning border-danger text-danger",onClick:n[1]||(n[1]=i=>e.deleteVault())},"Delete Vault")])])):u("",!0)])):u("",!0),h(V,{id:"keep-details",size:"modal-lg"},{body:D(()=>[h(b,{keep:e.activeKeep},null,8,["keep"])]),_:1})],64)}const ue=K(B,[["render",ie]]);export{ue as default};
