import{_ as f,o as k,q as v,b as K,A as t,c as l,K as g,M as h,d as y,e as a,f as s,F as d,r as M,h as o,w,k as x,l as C,P as A,i as n,j as c,a as D}from"./index.ee3dfb14.js";const P={setup(){async function r(){try{await x.getAllKeeps()}catch(e){C.error(e),A.error(e)}}return k(()=>{r()}),v(()=>{var e;(e=t.account)!=null&&e.id&&D.getMyVaults()}),K(()=>{t.keeps=[]}),{account:l(()=>t.account),keeps:l(()=>t.keeps)}},components:{KeepCard:g,Modal:h,KeepDetails:y}},S={class:"container-fluid"},B={class:"row justify-content-center"},V={class:"col-md-12"},$={class:"masonry"};function j(r,e,E,p,F,H){const _=n("KeepCard"),i=n("KeepDetails"),u=n("Modal");return c(),a(d,null,[s("div",S,[s("div",B,[s("div",V,[s("section",$,[(c(!0),a(d,null,M(p.keeps,m=>(c(),a("div",null,[o(_,{keep:m,title:"See Keep Details"},null,8,["keep"])]))),256))])])])]),o(u,{id:"keep-details"},{default:w(()=>[o(i)]),_:1})],64)}const b=f(P,[["render",j],["__scopeId","data-v-429cd23e"]]);export{b as default};
