<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input400">
			<div>银行：</div>
      <el-select v-model="bankId" class="m-2" placeholder="选择银行查询" size="large">
        <el-option
      key=""
      label="请选择"
      value="请选择"
    />
    <el-option
      v-for="item in banks"
      :key="item.bankId"
      :label="item.bankName"
      :value="item.bankId"
    />
  </el-select>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="bankName" label="银行名称" width="200" align="center"></el-table-column>
		<el-table-column prop="cardNo" label="卡号" width="200" align="center"></el-table-column>
		<el-table-column prop="bindRealName" label="绑定人姓名" width="200" align="center"></el-table-column>
		<el-table-column prop="bankAddress" label="开户行地址" width="200" align="center"></el-table-column>
		<el-table-column prop="minPayeeAmount" label="最低收款金额($)" width="200" align="center"></el-table-column>
		<el-table-column prop="maxPayeeAmount" label="最高收款金额($)" width="200" align="center"></el-table-column>
		<el-table-column prop="isEnable" label="是否启用" width="200" align="center">
			<template #default="scope">
				{{ scope.row.isEnable=="1"?"启用":"禁用"}}
			</template>
		</el-table-column>
   <el-table-column prop="startTime" label="开启时间" width="200" align="center">	</el-table-column>
    <el-table-column prop="endTime" label="关闭时间" width="200" align="center"></el-table-column>
		<el-table-column prop="" label="操作" align="center" width="130"  fixed="right">
			<template #default="scope">
				<el-space>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
	</div>
	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="700px">
		<el-row>
      <el-col :span="11" :offset="1">
					<el-form-item label="银行：">
				<el-select v-model="editItem.bankId" class="in-input200" size="large" placeholder="选择银行" >
					<el-option
      v-for="item in banks"
      :key="item.bankId"
      :label="item.bankName"
      :value="item.bankId"
        />
         </el-select>
			</el-form-item>
      </el-col>
      <el-col :span="11" :offset="1">
				<el-form-item label="卡号：">
        <el-input  v-model="editItem.cardNo" class="in-input200"></el-input>
				</el-form-item>
      </el-col>
			</el-row>
    <el-row>
      <el-col :span="11" :offset="1">
					<el-form-item label="开启时间：">
			<el-input  style="width:50px;" v-model="start1" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2" ></el-input><span>：</span>
			<el-input  style="width:50px;" v-model="start2" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2"></el-input><span>：</span>
				<el-input  style="width:50px;" v-model="start3" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2" ></el-input><span></span>
			</el-form-item>
      </el-col>
      <el-col :span="11" :offset="1">
				<el-form-item label="关闭时间：">
      <el-input  style="width:50px;" v-model="end1" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2" ></el-input><span>：</span>
			<el-input  style="width:50px;" v-model="end2" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2"></el-input><span>：</span>
				<el-input  style="width:50px;" v-model="end3" oninput="value=value.replace(/[^\d]/g,'')" maxlength="2" ></el-input><span></span>
			</el-form-item>
      </el-col>
			</el-row>
    <el-row>
      <el-col :span="11" :offset="1">
					<el-form-item label="绑卡人姓名：">
		<el-input  v-model="editItem.bindRealName" class="in-input163"></el-input>
			</el-form-item>
      </el-col>
      <el-col :span="11" :offset="1">
				<el-form-item label="开户行地址：">
        <el-input  v-model="editItem.bankAddress" class="in-input163"></el-input>
				</el-form-item>
      </el-col>
			</el-row>
<el-row>
      <el-col :span="11" :offset="1">
					<el-form-item label="最低收款金额：">
		<el-input  v-model="editItem.minPayeeAmount" class="in-input160"></el-input>
			</el-form-item>
      </el-col>
      <el-col :span="11" :offset="1">
				<el-form-item label="最高收款金额：">
        <el-input  v-model="editItem.maxPayeeAmount" class="in-input160"></el-input>
				</el-form-item>
      </el-col>
			</el-row>
			<el-row>
      <el-col :span="11" :offset="1">
					<el-form-item label="是否启用：">
		<el-radio-group v-model="editItem.isEnable"  class="in-input">
        <el-radio label="1" >启用</el-radio>
        <el-radio label="0" >禁用</el-radio>
      </el-radio-group>
			</el-form-item>
      </el-col>
     
			</el-row>
					<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
	</el-dialog>
</template>

<script>
	export default {
		name: "BankCard",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
				start1:'00',
				start2:'00',
				start3:'00',
				end1:'00',
				end2:'00',
				end3:'00',
				bankId: '',
        banks :[],//银行下拉选择列表
				contentHeight: '0px',

				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,

				windowStatus: false,
				editItem: {},
				windowSaving: false,
			}
		},
    created(){
      this.$Http.get('AdminBank/GetBankList').then(res => {
				this.banks=res.data.data;
			})
    },
		methods: {
			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.cardNo + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
								const urldelete = decodeURI(encodeURI('AdminPayeeBankCard​/PayeeBankCardDelete').replace(/%E2%80%8B/g, ""));
							this.$Http.post(urldelete, {id: item.id}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})
			},
			saveItem() {
				if (!this.editItem.bankId) {
					this.$message.error('请选择银行');
					return;
				}
				if (!this.editItem.cardNo) {
					this.$message.error('请输入卡号');
					return;
				}
			if (!this.editItem.bindRealName) {
					this.$message.error('请输入银行卡绑定人');
					return;
				}
				if (!this.editItem.bankAddress) {
					this.$message.error('请输入开户行地址');
					return;
				}
					if (!this.editItem.minPayeeAmount) {
					this.$message.error('请输入最低收款金额');
					return;
				}
					if (!this.editItem.maxPayeeAmount) {
					this.$message.error('请输入最高收款金额');
					return;
				}
				this.windowSaving = true;
				this.editItem.startTime=this.start1+":"+this.start2+":"+this.start3;
				this.editItem.endTime=this.end1+":"+this.end2+":"+this.end3;
				if (this.editItem.id) {
					const urlcread = decodeURI(encodeURI('AdminPayeeBankCard​/PayeeBankCardUpdate').replace(/%E2%80%8B/g, ""));
					this.$Http.post(urlcread, this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					const urlupdate = decodeURI(encodeURI('AdminPayeeBankCard​/PayeeBankCardCreate').replace(/%E2%80%8B/g, ""));
					this.$Http.post(urlupdate, this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				}

			},
			addItem() {
				this.editItem = {};
				this.windowStatus = true;
				this.windowSaving = false;
			this.editItem.isEnable ='1';
			},
			updItem(item) {
				this.windowStatus = true;
				this.windowSaving = false;
				this.editItem = JSON.parse(JSON.stringify(item));
				var startArray=this.editItem.startTime.split(':');
				var endArray=this.editItem.endTime.split(':');
					this.start1=startArray[0];
					this.start2=startArray[1];
					this.start3=startArray[2];
					this.end1=endArray[0];
					this.end2=endArray[1];
					this.end3=endArray[2];
			this.editItem.isEnable =''+ item.isEnable+'';
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
			},
			getTableHeight() {
				this.$nextTick(() => {
					let searchInfo = document.getElementById('search-info');
					let searchButton = document.getElementById('search-button');
					let page = document.getElementById('page');

					let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

					this.contentHeight = 'calc(100% - ' + height + ')'
				})
			},

			loadData(page) {
				let param = {};
				if (this.bankId) {
					param.bankId = this.bankId;
				}
				if (page) {
					this.pageIndex = page;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
        const url = decodeURI(encodeURI('AdminPayeeBankCard​/GetPayeeBankCardPagedList').replace(/%E2%80%8B/g, ""));
				this.$Http.get(url, {params: param}).then(res => {
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>