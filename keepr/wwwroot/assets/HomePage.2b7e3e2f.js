import{_ as h,w as k,o as K,c as o,k as u,M as g,P as c,K as M,a as w,b as C,d as n,e as a,F as m,f as A,g as r,h as x,i,j as l,A as s,p as b}from"./index.5d71e8d8.js";const P={setup(){async function d(){try{await u.getAllKeeps()}catch(e){c.error(e)}}async function p(){try{await b.getVaults(s.account.id)}catch(e){c.error(e.response.data)}}return k(()=>{s.account.id,p()}),K(()=>{d()}),{keeps:o(()=>s.keeps),activeKeep:o(()=>s.activeKeep),vaults:o(()=>s.vaults),async setActive(e){try{await u.setActive(e),g.getOrCreateInstance("#keep-details").show()}catch(t){c.error(t)}}}},components:{KeepCard:M,MyModal:w,KeepDetails:C}},V={class:"container-fluid"},B={class:"row justify-content-center my-4"},D={class:"col-12 col-md-10"},S={class:"masonry-with-columns"},j=["onClick"];function E(d,p,e,t,F,H){const v=i("KeepCard"),y=i("KeepDetails"),f=i("MyModal");return l(),n(m,null,[a("div",V,[a("div",B,[a("div",D,[a("div",S,[(l(!0),n(m,null,A(t.keeps,(_,N)=>(l(),n("div",{class:"mb-4",onClick:$=>t.setActive(_.id)},[r(v,{keep:_,class:"selectable rounded"},null,8,["keep"])],8,j))),256))])])])]),r(f,{id:"keep-details",size:"modal-lg"},{body:x(()=>[r(y,{keep:t.activeKeep},null,8,["keep"])]),_:1})],64)}const I=h(P,[["render",E]]);export{I as default};
